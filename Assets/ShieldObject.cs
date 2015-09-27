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

		//Debug.Log (GameManager.Instance.curTimes);
		if(GameManager.Instance.curTimes>1)//Time.time - lasttime > 30
		{
//			Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = Player.transform;
			start = false;
		}

		lasttime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevel == 2) 
		{

			if (start && Mathf.Abs (Camera.main.gameObject.transform.position.x - transform.position.x) <= 0.01f) 
			{
				lasttime = Time.time;
					
				start = false;
			}
				

			if (Time.time - lasttime > 3.5f) 
			{
				Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = Player.transform;
			}
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
