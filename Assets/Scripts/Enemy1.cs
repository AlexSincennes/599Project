using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
	public const int WALK = 1;
	public const int ATTACK = 2;
	public const int IDLE = 3;
	public const int GETHIT = 4;

	public float attackDis;
	public float patrolDis;
	public Vector3 targetPosition;
	public Vector3 startPosition;
	public float Speed = 3;
	public GameObject Arrow;
	public Transform Bow;
	public float attackRate;

	private int state = WALK;
	private bool moveLeft = true;
	private bool canAttack = false;
	private float lastAttackTime = 0;

	public static Transform player = null;


	// Use this for initialization
	void Start () {
		if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {

		float dis = 0;
		dis = Vector3.Distance(player.position, transform.position);

		if (dis > attackDis) {
			SetState (WALK);

		} else if(state != IDLE && moveLeft && canAttack){
			SetState (ATTACK);
		}

		switch (state) {
		case WALK:
			//lastAttackTime = 0;
			if(moveLeft)
			{
				if(transform.position.x == startPosition.x - patrolDis)
				{
					moveLeft = false;
				}else
				{
					targetPosition = new Vector3(startPosition.x - patrolDis, transform.position.y ,0);
				}
			}else
			{
				if(transform.position.x == startPosition.x + patrolDis)
				{
					moveLeft = true;
				}else
				{
					targetPosition = new Vector3(startPosition.x + patrolDis, transform.position.y ,0);
				}
			}
			break;
		case ATTACK:
			if(Time.time - lastAttackTime > attackRate)
			{
				//GameObject temp = (GameObject) Instantiate( Arrow, Bow. position, Arrow.transform.rotation );
				lastAttackTime = Time.time;
			}
				

			//temp.transform.parent = this.transform;
			//SetState(IDLE);
			break;
		case IDLE:

			break;
		case GETHIT:

			break;
		}

		targetPosition.y = transform.position.y;
		Vector3 targetRotation = Vector3.zero;
		if (moveLeft && state != ATTACK&& state != IDLE) {
			targetRotation = new Vector3 (0, 180, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * 5);
		} else if (!moveLeft && state != ATTACK&& state != IDLE){
			targetRotation = new Vector3 (0, 0, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * 5);
		}

		//
		//Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
		//transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
		if (transform.eulerAngles.y - targetRotation.y <=0f) {
			canAttack = true;
		} else 
		{
			canAttack = false;
		}
	}

	public void SetState(int state) 
	{
		if (this.state == state)
			return;
		this.state = state;
		switch (state) {
		case WALK:
			Speed = 3;
			break;
		case ATTACK:
			Speed = 0;
			break;
		case IDLE:
			Speed = 0;
			break;
		case GETHIT:
			Speed = 0;
			break;
		}
	}
}
	