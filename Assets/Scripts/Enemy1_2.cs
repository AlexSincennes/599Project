using UnityEngine;
using System.Collections;

public class Enemy1_2 : MonoBehaviour {
	public const int WALK = 1;
	public const int ATTACK = 2;
	public const int IDLE = 3;
	public const int GETHIT = 4;
	
	public float attackDis;
	public float patrolDis;
	public Vector3 targetPosition;
	public Vector3 startPosition;
	public float Speed = 3;
	public float RotateSpeed = 20;
	public GameObject Bullet;
	public Transform Bow;
	public float attackRate;
    private float walkingSpeed;
	
	public int state = WALK;
	public bool moveLeft = true;
	//private bool canAttack = false;
	private float lastAttackTime = 0;
	
	public static Transform player = null;
	
	
	// Use this for initialization
	void Start () {
		if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
        walkingSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (state) {
		case WALK:
			//lastAttackTime = 0;
			if(moveLeft)
			{
				if(transform.position.x - startPosition.x + patrolDis <= 0.01f)
				{
					moveLeft = false;
				}else
				{
					targetPosition = new Vector3(startPosition.x - patrolDis, transform.position.y ,0);
				}
			}else
			{

				if(startPosition.x + patrolDis - transform.position.x   <= 0.01f)
				{
					moveLeft = true;
				}else
				{
					//Debug.Log("lalalalal");
					targetPosition = new Vector3(startPosition.x + patrolDis, transform.position.y ,0);
				}
			}
			break;
		case ATTACK:
			if(Time.time - lastAttackTime > attackRate)
			{ 
				GameObject temp = (GameObject) Instantiate( Bullet, Bow.position,Bullet.transform.rotation );
				temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
				temp.transform.GetComponentInChildren<BulletTest>().enemy = player;
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
		
		//targetPosition.y = transform.position.y;
		Vector3 targetRotation = Vector3.zero;
		if (moveLeft && state != ATTACK&& state != IDLE) {
			targetRotation = new Vector3 (0, 180, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		} else if (!moveLeft && state != ATTACK&& state != IDLE){
			targetRotation = new Vector3 (0, 0, 0);
			transform.eulerAngles = Vector3.Lerp (this.transform.eulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		}
		
		//
		//Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
		//transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);
		
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * walkingSpeed);
		
	}
	
	public void SetState(int state) 
	{
		if (this.state == state)
			return;
		this.state = state;
		switch (state) {
		case WALK:
			walkingSpeed = Speed;
			break;
		case ATTACK:
			walkingSpeed = 0;
			break;
		case IDLE:
			walkingSpeed = 0;
			break;
		case GETHIT:
			walkingSpeed = 0;
			break;
		}
	}
	
	
	
	
}
