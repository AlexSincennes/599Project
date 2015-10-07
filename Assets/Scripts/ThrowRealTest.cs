using UnityEngine;
using System.Collections;

public class ThrowRealTest : MonoBehaviour {
	public float angle;
	public float velocity;
	//float dis;
	// Use this for initialization
	void Start () {
		//dis = Mathf.Abs (Enemy1.player.position.x - transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {

	}


	
	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Player")
			Destroy(this.gameObject);
	}
}
