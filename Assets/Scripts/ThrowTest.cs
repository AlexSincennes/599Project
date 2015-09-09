using UnityEngine;
using System.Collections;

public class ThrowTest : MonoBehaviour {
	public float thrust;
	public Rigidbody rb;
	private bool isStart;
	// Use this for initialization
	void Start () {
		isStart = false;
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
