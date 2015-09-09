using UnityEngine;
using System.Collections;

public class BulletTest : MonoBehaviour {
	public Transform shooter;
	private float dis;
	private Vector3 targetposion;
	private bool isLeft = false;
	
	public Transform enemy;
	// Use this for initialization
	void Start () {
		if (shooter.name != "Shield") {
			if (shooter.eulerAngles.y < 10) {
				isLeft = false;
				targetposion = transform.parent.position - enemy.position;
			} else  if (shooter.eulerAngles.y > 10) {
				isLeft = true;
				targetposion = enemy.position - transform.parent.position;
			}
		} else {
			isLeft = true;
			targetposion = enemy.position - transform.parent.position;
		}
		
		
		
		transform.eulerAngles = new Vector3(0,0,(Mathf.Acos(Vector3.Dot(targetposion,Vector3.up) / targetposion.magnitude))* Mathf.Rad2Deg);
		//transform.eulerAngles = new Vector3 (0,0,initialAngle);
		//dis = Mathf.Abs (transform.position.x - Enemy1_2.player.position.x); 
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.position = Vector3.MoveTowards(transform.position, targetposion , Time.deltaTime * Speed);
		if (!isLeft) {
			transform.parent.Translate (-targetposion*Time.deltaTime);
		} else  if (isLeft) {
			transform.parent.Translate (targetposion*Time.deltaTime);
		}
		
	}	
	

	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player" && shooter.name != "Shield") {

			//other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>().reflectItem = this.transform.parent.gameObject;
			ShieldTest temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			if(temp.shieldEquip)
			{
				temp.attacker = shooter;
				temp.canReflect = true;
				temp.startClock = true;
			}else
			{
				Application.LoadLevel(0);

			}

			Destroy(transform.parent.gameObject);
			
		}
		//Debug.Log (other.transform.name +"------------hahaha" + shooter.name );
		if (other.transform.gameObject.tag == "Enemy" && shooter.name == "Shield") 
		{

			Destroy(other.transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
		}
	}


}
