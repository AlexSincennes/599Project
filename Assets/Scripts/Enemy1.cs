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

	private int state = WALK;
	private bool moveLeft = true;
	private bool canAttack = false;
	private static Transform player = null;


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
			Instantiate( Arrow, Bow. position, Arrow.transform.rotation );
			SetState(IDLE);
			break;
		case IDLE:

			break;
		case GETHIT:

			break;
		}

		targetPosition.y = transform.position.y;
		Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
		transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
		if (transform.rotation.y - rotationTarget.y <0.2f) {
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
	