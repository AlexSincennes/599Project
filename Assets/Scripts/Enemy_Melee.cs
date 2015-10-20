using UnityEngine;
using System.Collections;

public class Enemy_Melee : MonoBehaviour {
	public const int WALK = 1;
	public const int ATTACK = 2;
	public const int IDLE = 3;
	public const int GETHIT = 4;
	public const int FOLLOW = 5;

	public float attackDis;
	public float patrolDis;
	public float followDis;

	public Vector3 targetPosition;
	public Vector3 startPosition;

	public float curSpeed = 3;
	public float RotateSpeed = 20;

	public float attackRate;
	public bool moveLeft = true;

	private bool canAttack = false;
	private Transform player = null;
	private int state = WALK;
	private float lastAttackTime = 0;

	private Animation myAni;

	void Start () {
		if(player == null) {
			player = GameManager.Instance.player.transform;
		}

		myAni = transform.GetComponentInChildren<Animation> ();
	}

	void Update () {
		
		switch (state) {
		case WALK:
			myAni.CrossFade("run",0.1f);

			if(moveLeft)
			{//
				if(transform.position.x - startPosition.x + patrolDis <= 0.01f || transform.position.x - startPosition.x + followDis <= 0.01f)
				{
					moveLeft = false;
				}else
				{
					targetPosition = new Vector3(startPosition.x - patrolDis, transform.position.y ,0);
				}
			}else//|| startPosition.x + followDis - transform.position.x   <= 0.01
			{
				if(startPosition.x + patrolDis - transform.position.x   <= 0.01f || startPosition.x + followDis - transform.position.x   <= 0.01)
				{
					moveLeft = true;
				}else
				{
					targetPosition = new Vector3(startPosition.x + patrolDis, transform.position.y ,0);
				}
			}
			break;
		case ATTACK:
			float dis_attack1 = Vector3.Distance(transform.position,player.position);
			if(Time.time - lastAttackTime > attackRate)
			{
				myAni["stun2"].wrapMode = WrapMode.Once;
				myAni.Play("stun2");
				lastAttackTime = Time.time;
			}
			//Debug.Log(dis_attack1);
			if(myAni["stun2"].normalizedTime >=0.9f && dis_attack1 - attackDis <= 1.5f)
			{
				player.GetComponentInChildren<HitBox>().Die();
			}
			float dis_attack = Mathf.Abs(transform.position.x - player.position.x);
			if(dis_attack - attackDis > 0.01f && !myAni.IsPlaying("stun2"))
			{
				SetState(FOLLOW);
			}
			break;
		case IDLE:
			break;
		case GETHIT:
			break;
		case FOLLOW:
			myAni.CrossFade("run",0.1f);
			float dis = Mathf.Abs(transform.position.x - player.position.x);
			if(dis - attackDis <= 0.01f)
			{
				SetState(ATTACK);
			}else
			{
				if(transform.position.x - startPosition.x + followDis <= 0.01f || startPosition.x + followDis - transform.position.x   <= 0.01)
				{
					SetState(WALK);
					targetPosition = transform.position;
				}else
				{
					targetPosition = new Vector3(player.position.x, transform.position.y ,0);	
				}
					
			}
			break;
		}


		Vector3 targetRotation = Vector3.zero;
		if (moveLeft ) { //&& state != ATTACK&& state != IDLE
			targetRotation = new Vector3 (0, 180, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		} else if (!moveLeft ){ //&& state != ATTACK&& state != IDLE
			targetRotation = new Vector3 (0, 0, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		}

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * curSpeed);
	}

	public void SetState(int state) 
	{
		if (this.state == state)
			return;
		this.state = state;
		switch (state) {
		case WALK:
			curSpeed = 3;
			break;
		case ATTACK:
			curSpeed = 0;
			break;
		case IDLE:
			curSpeed = 0;
			break;
		case GETHIT:
			curSpeed = 0;
			break;
		case FOLLOW:
			curSpeed = 6;
			break;
		}
	}


	
}
