using UnityEngine;
using System.Collections;

public class ThrowTest : MonoBehaviour {
	private float thrust;
	public Rigidbody rb;
	private bool isStart;
	public float initialAngle;

	private float dis;

	// Use this for initialization
	void Start () {
		isStart = false;
		transform.eulerAngles = new Vector3 (0,0,initialAngle);
		dis = Mathf.Abs (transform.position.x - Enemy1_1.player.position.x); 
	}
	
	// Update is called once per frame
	void Update () {

		startForce();
		transform.rotation = Quaternion.FromToRotation (Vector3.up, GetComponent<Rigidbody>().velocity.normalized);


	}

	void startForce()
	{
		if (!isStart) {

			rb = GetComponent<Rigidbody> ();
			thrust = (70)* (Mathf.Log10(dis))/(Mathf.Log10(15));

			rb.AddForce (transform.up * thrust);
			isStart = true;
		}
	}

	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Player")
			Destroy(this.gameObject);
	}
}
