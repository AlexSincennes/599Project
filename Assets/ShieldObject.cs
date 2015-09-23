using UnityEngine;
using System.Collections;

public class ShieldObject : MonoBehaviour {
	public GameObject Player;
	//public static Transform player = null;
	// Use this for initialization
	private bool start  = true;
	private float lasttime = 0;
	void Start () {
		lasttime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (start && Mathf.Abs (Camera.main.gameObject.transform.position.x - transform.position.x) <= 0.01f) 
		{
			lasttime = Time.time;

			start = false;
		}
		if (Time.time - lasttime > 4) 
		{
			Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = Player.transform;
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>()) {
			ShieldTest temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			temp.shieldEquip = true;
			Destroy(this.gameObject);
		}
	}
}
