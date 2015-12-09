using UnityEngine;
using System.Collections;

public class DetectEnemy2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void OnTriggerStay2D(Collider2D other) 
	//{
	//}
	void OnTriggerEnter2D(Collider2D other)
	{
		//if(transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ())
		//	transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ().SetState (2);

		//if(transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ())
		//	transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ().SetState (Enemy_Melee.FOLLOW);

		if (other.gameObject.tag == "Player") 
		{
			if(transform.parent.gameObject.GetComponent<Enemy1_2> ())
				transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (2);
			
		}
	}


	void OnTriggerExit2D(Collider2D other) 
	{

		if (other.gameObject.tag == "Player") 
		{
			if(transform.parent.gameObject.GetComponent<Enemy1_2> ())
				transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (3);
            //if (transform.parent.gameObject.GetComponent<EnemyStandStill>())
            //    transform.parent.gameObject.GetComponent<EnemyStandStill>().SetState(1);
           // if (transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ())
			//	transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ().SetState (1);

			//if(transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ())
			//	transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ().SetState (Enemy_Melee.WALK);
		}
			
	}
	
	void OnCollisionEnter2D(Collision2D collision) 
	{
		if( collision.gameObject.tag == "Player")
			Destroy(transform.parent.gameObject);
	}
}
