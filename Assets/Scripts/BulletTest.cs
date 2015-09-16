using UnityEngine;
using System.Collections;

public class BulletTest : MonoBehaviour {
	public Transform shooter;
	//private float dis;
	//private Vector3 targetposion;
	//private bool isLeft = false;
	
	public Transform enemy;
    public float speed=5;
	// Use this for initialization
	void Start ()
    {
        Vector3 enemyPos = enemy.transform.position - shooter.transform.position;
        float dirEuler = Mathf.Acos(enemyPos.y / enemyPos.magnitude) * Mathf.Sign(enemyPos.x);
        transform.eulerAngles = new Vector3(0, 0, -dirEuler * Mathf.Rad2Deg);
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Sin(dirEuler), speed * Mathf.Cos(dirEuler), 0);
    }
	
	// Update is called once per frame
	void Update ()
    {	
	}	
	
	
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player" && shooter.name != "Shield") {
			ShieldTest temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			//other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>().reflectItem = this.transform.parent.gameObject;
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
