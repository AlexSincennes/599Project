using UnityEngine;
using System.Collections;

public class EnemyKeepAttack : MonoBehaviour {
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
	
	public int state = ATTACK;
	public bool moveLeft = true;
	private bool canAttack = false;
	private float lastAttackTime = 0;
	
	public static Transform player = null;

	public GameObject Target;
	
	// Use this for initialization
	void Start () {
		if(player == null) {
			//player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		

			if(Time.time - lastAttackTime > attackRate)
			{ 
				GameObject temp = (GameObject) Instantiate( Bullet, Bow.position,Bullet.transform.rotation );
				temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
				temp.transform.GetComponentInChildren<BulletTest>().enemy = Target.transform;
                temp.transform.GetComponentInChildren<BulletTest>().ifKeepShooting = true;
            lastAttackTime = Time.time;
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
