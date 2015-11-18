using UnityEngine;
using System.Collections;

public class BulletTest_P : MonoBehaviour {
	public Transform shooter;
	//private float dis;
	//private Vector3 targetposion;
	//private bool isLeft = false;
	public int i=0;
	
	public Transform enemy;
	public float speed=5;
	private Vector3 oriSpeed;
	private Rigidbody2D myRigid;
	private Vector3 angle;
	public float liveTime;
	private float startTime;
	public bool ifKeepShooting=false;
	public bool ifHardCodeAngle = false;
	float dirEuler;
	public float angleKeepShooting=0;
	public float angleHardCode = 0;
	private float time;
	public float deflectBuffer = 38;

	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
		myRigid = this.GetComponent<Rigidbody2D>();
		
		if (ifKeepShooting)
			dirEuler = angleKeepShooting;
		//else if (ifHardCodeAngle)
		//dirEuler = angleHardCode;
		else
		{
			float runSpeed = GameObject.Find("Character2D").GetComponent<RaycastCharacterController2D>().movement.walkSpeed;

			Vector3 enemyPos = enemy.transform.position - shooter.transform.position; //- new Vector3(0,-1f,0);

			//Debug.Log(shooter.transform.position.y+" "+enemy.transform.position.y);
			if(shooter.transform.position.y-2 <= enemy.transform.position.y)
			{
				enemyPos -=new Vector3(0,-1f,0);
			}

			{
				dirEuler = - Mathf.PI;
				float delta = dirEuler / 36f;
				
				
				while (enemyPos.x * Mathf.Cos(dirEuler) * speed / (Mathf.Sin(dirEuler) * speed - runSpeed) + enemyPos.x * enemyPos.x
				       / (speed * Mathf.Sin(dirEuler) - runSpeed) / (speed * Mathf.Sin(dirEuler) - runSpeed) * Physics.gravity.y / 2.0f - enemyPos.y < 0 && dirEuler < 0)
					dirEuler -= delta;
				
				
				delta *= 0.5f;
				dirEuler += delta;
				
				while (true)
				{
					float temp = enemyPos.x * Mathf.Cos(dirEuler) * speed / (Mathf.Sin(dirEuler) * speed - 10) + enemyPos.x * enemyPos.x
						/ (speed * Mathf.Sin(dirEuler) - 10) / (speed * Mathf.Sin(dirEuler) - 10) * Physics.gravity.y / 2.0f - enemyPos.y;
					if (Mathf.Abs(temp) < 0.05f || Mathf.Abs(delta)<0.005f)
						
						break;
					delta *= 0.5f;
					if (temp > 0)
						dirEuler += delta;
					else
						dirEuler -= delta;
				}
				time = enemyPos.x / (Mathf.Sin(dirEuler) * speed - 10);
			}
		}
		angle=transform.eulerAngles = new Vector3(0, 0, -dirEuler * Mathf.Rad2Deg);
		myRigid.velocity=oriSpeed = new Vector2 (speed * Mathf.Sin (dirEuler), speed * Mathf.Cos (dirEuler));
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - startTime > liveTime) 
		{
			Destroy(this.transform.parent.gameObject);
		}
		if (myRigid.velocity.magnitude < 2.0f) return;
		transform.eulerAngles = new Vector3(0, 0, Mathf.Acos(oriSpeed.y/oriSpeed.magnitude) * Mathf.Sign(oriSpeed.x) * Mathf.Rad2Deg);
		oriSpeed = myRigid.velocity;
		transform.eulerAngles = new Vector3(0, 0, -Mathf.Acos(oriSpeed.y / oriSpeed.magnitude) * Mathf.Sign(oriSpeed.x) * Mathf.Rad2Deg);
		
		
	}
	
	
	
	void OnCollisionEnter2D(Collision2D other) 
	{
		//Debug.Log (other.gameObject.tag);
		
		if (other.gameObject.tag == "Player" && myRigid.velocity.magnitude > 0.2f && (shooter == null || shooter.name != "Shield")) 
		{
			//Debug.Log(shooter.name);
			//player = other.gameObject;
			//if(spawnpoint!=null)
			//spawn = spawnpoint.transform.position;
			//Debug.Log("lala");
			HitBox_2D health = other.gameObject.GetComponent<HitBox_2D>();
			if (health != null) health.Damage(1);
		}
		
		
		if (other.gameObject.tag == "Shield" && (shooter == null || shooter.name != "Shield")) {
			//Debug.Log (other.transform.name +"------------hahaha" + shooter.name );
			ShieldControl2D temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldControl2D>();
			//other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>().reflectItem = this.transform.parent.gameObject;
			if(temp.shieldEquip )
			{
				//temp.attacker = shooter;
				//temp.canReflect = true;
				//temp.startClock = true;
				transform.GetComponent<BoxCollider2D>().isTrigger = true;
				myRigid.velocity = -oriSpeed+new Vector3(0.5f/ time, 0, 0);
				transform.GetComponent<BoxCollider2D>().isTrigger = false;
				//transform.GetComponent<Rigidbody>().c
				//transform.GetComponent<Rigidbody>().isKinematic = false;
				shooter = other.transform;
			}
			
			
			//Destroy(transform.parent.gameObject);
			
		}
		
		if (other.gameObject.tag == "Enemy" && shooter.name == "Shield") 
		{
			Destroy(other.transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
		}
		
		if (other.gameObject.tag == "Terrain") 
		{
			transform.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
			transform.GetComponent<Rigidbody2D>().isKinematic = true;
			transform.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player" && myRigid.velocity.magnitude > 0.2f && (shooter == null || shooter.name != "Shield")) 
		{

			HitBox_2D health = other.gameObject.GetComponent<HitBox_2D>();
			if (health != null) health.Damage(1);
		}

		if (other.gameObject.tag == "Shield" && (shooter == null || shooter.name != "Shield")) {
			ShieldControl2D temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldControl2D>();
			if(temp.shieldEquip )
			{
				Debug.Log(transform.eulerAngles.z);
				//Debug.Log(Mathf.Abs(transform.eulerAngles.z -90 - other.transform.parent.GetComponent<ShieldControl2D>().swipeAngle));

				if( temp.angle > transform.eulerAngles.z -90-deflectBuffer && temp.angle < transform.eulerAngles.z -90+deflectBuffer
				   )
				{
					myRigid.velocity = -oriSpeed+new Vector3(0.5f/ time, 0, 0);
					shooter = other.transform;
				}

			}			
		}

		if (other.gameObject.tag == "Enemy" && shooter.name == "Shield") 
		{
			Destroy(other.transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
		}

		if (other.gameObject.tag == "Terrain") 
		{
			transform.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
			transform.GetComponent<Rigidbody2D>().isKinematic = true;
			transform.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
