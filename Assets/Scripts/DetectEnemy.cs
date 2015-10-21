using UnityEngine;
using System.Collections;

public class DetectEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		//Debug.Log ("lalala");
		if (other.gameObject.tag == "Player") 
		{
			if(transform.parent.gameObject.GetComponent<Enemy1_2> ())
				transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (2);
            if (transform.parent.gameObject.GetComponent<EnemyStandStill>())
                transform.parent.gameObject.GetComponent<EnemyStandStill>().SetState(2);
        }
			
	}
	void OnTriggerEnter(Collider other)
	{
		if(transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ())
			transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ().SetState (2);

		if(transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ())
			transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ().SetState (Enemy_Melee.FOLLOW);
	}

	void OnTriggerExit(Collider other) 
	{

		if (other.gameObject.tag == "Player") 
		{
			if(transform.parent.gameObject.GetComponent<Enemy1_2> ())
				transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (1);
            if (transform.parent.gameObject.GetComponent<EnemyStandStill>())
                transform.parent.gameObject.GetComponent<EnemyStandStill>().SetState(1);
            if (transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ())
				transform.parent.gameObject.GetComponentInChildren<EnemyMelee> ().SetState (1);

			if(transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ())
				transform.parent.gameObject.GetComponentInChildren<Enemy_Melee> ().SetState (Enemy_Melee.WALK);
		}
			
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		if( collision.gameObject.tag == "Player")
			Destroy(transform.parent.gameObject);
	}
}
