using UnityEngine;
using System.Collections;

public class BulletTest_Homing : MonoBehaviour {
	public Transform shooter;
	public Transform target;

	public float speed=5;
	public float liveTime;
	private float startTime;

	private float time;

	// Use this for initialization
	void Start()
	{
		startTime = Time.time;		


	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - startTime > liveTime) 
		{
			Destroy(this.transform.gameObject);
			//Destroy(this.transform.parent.gameObject);
		}


	}

	void FixedUpdate()
	{
		if (target == null)
			return;

		Vector3 dir;

		//if (target.tag == "Player") {

		//	dir = ((target.position + new Vector3 (0, 0.5f, 0)) - this.transform.position).normalized;
		//} else {
			dir = ((target.position ) - this.transform.position).normalized;
	//	}
		
		Vector2 vol = new Vector2 (dir.x ,dir.y);

		transform.GetComponent<Rigidbody2D> ().velocity = vol * speed;

		transform.rotation = Quaternion.FromToRotation (Vector3.up, GetComponent<Rigidbody2D>().velocity.normalized);


	}
	
	
	void OnCollisionEnter2D(Collision2D other) 
	{
		
		if (other.gameObject.tag == "Player" && (shooter == null || shooter.name != "Shield")) 
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
				float angle = 0;
				Vector3 axis = Vector3.zero;
				transform.rotation.ToAngleAxis(out angle,out axis);	
				Debug.Log(angle);
				target = shooter;
				shooter = other.transform;

				//Debug.Log (target.position);
			}
			
			
			//Destroy(transform.parent.gameObject);
			
		}
		
		if (other.gameObject.tag == "Enemy" && shooter.name == "Shield") 
		{
			Destroy(other.transform.parent.gameObject);
			Destroy(transform.gameObject);
		}
		
		if (other.gameObject.tag == "Terrain") 
		{
			//transform.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
			//transform.GetComponent<Rigidbody2D>().isKinematic = true;
			transform.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	
	
}
