using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour {
	public const int WALK = 1;
	public const int ATTACK = 2;
	public const int IDLE = 3;
	public const int GETHIT = 4;
	public const int TRACK = 5;

	
	public float attackDis;
	public float patrolDis;
	public Vector3 targetPosition;
	public Vector3 startPosition;
	public float Speed = 3;
	public float RotateSpeed = 20;
	public GameObject Bullet;
	public Transform Bow;
	public float attackRate;
	
	public int state = WALK;
	public bool moveLeft = true;
	private bool canAttack = false;
	private float lastAttackTime = 0;
	public static GameObject spawnpoint = null;
	public static Vector3 spawn;
	public static Transform player = null;
	
	
	// Use this for initialization
	void Start () {
		if(player == null) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
			 
		}
		if (spawnpoint == null)
			spawnpoint = GameObject.FindGameObjectWithTag ("Spawn");
		patrolDis = transform.parent.FindChild("detection").lossyScale.x/2;
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (state) {
		case WALK:
			canAttack = false;
			break;
		case ATTACK:
			canAttack = true;
			if(player.position.x > startPosition.x + transform.parent.position.x)
			{
				if(moveLeft)
				{
					moveLeft = false;
				}
				targetPosition = new Vector3(startPosition.x + patrolDis, transform.localPosition.y ,0);
			}else if(player.position.x <=startPosition.x  + transform.parent.position.x)
			{
				if(!moveLeft)
				{
					moveLeft = true;
				}
				targetPosition = new Vector3(startPosition.x - patrolDis, transform.localPosition.y ,0);
			}

			break;
		
		}

		if (!canAttack) 
		{
			if(moveLeft)
			{
				if(transform.localPosition.x - startPosition.x + patrolDis <= 0.01f)
				{
					moveLeft = false;
				}else
				{
					targetPosition = new Vector3(startPosition.x - patrolDis, transform.localPosition.y ,0);
				}
			}else
			{
				
				if(startPosition.x + patrolDis - transform.localPosition.x   <= 0.01f)
				{
					moveLeft = true;
				}else
				{
					//Debug.Log("lalalalal");
					targetPosition = new Vector3(startPosition.x + patrolDis, transform.localPosition.y ,0);
				}
			}
		}

		//targetPosition.y = transform.position.y;
		Vector3 targetRotation = Vector3.zero;
		if (moveLeft  ) {
			targetRotation = new Vector3 (0, 180, 0);
			transform.localEulerAngles = Vector3.Lerp (this.transform.localEulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		} else if (!moveLeft ){
			targetRotation = new Vector3 (0, 0, 0);
			transform.localEulerAngles = Vector3.Lerp (this.transform.localEulerAngles, targetRotation, Time.deltaTime * RotateSpeed);
		}
		
		//
		//Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
		//transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);
		
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, Time.deltaTime * Speed);
		
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
			Speed = 6;
			break;
		case IDLE:
			Speed = 0;
			break;
		case GETHIT:
			Speed = 0;
			break;
		case TRACK:
			Speed = 10;
			break;
		
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Shield") 
		{
			Destroy(transform.parent.gameObject);
		}
					

	}
	
}
