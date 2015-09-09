using UnityEngine;
using System.Collections;

public class BulletTest : MonoBehaviour {
	public Transform shooter;
	private float dis;
	private Vector3 targetposion;
	private bool isLeft = false;
	// Use this for initialization
	void Start () {

		if (shooter.eulerAngles.y <10) {
			isLeft = false;
			targetposion = transform.parent.position - Enemy1_2.player.position;
		} else  if (shooter.eulerAngles.y > 10)
		{
			isLeft = true;
			targetposion = Enemy1_2.player.position - transform.parent.position;
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
		if(other.gameObject.tag == "Terrain" || other.gameObject.tag == "Player")
			Destroy(transform.parent.gameObject);
	}
}
