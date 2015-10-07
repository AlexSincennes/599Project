using UnityEngine;
using System.Collections;

public class ShieldObject : MonoBehaviour {
	public GameObject Player;
	//public static Transform player = null;
	// Use this for initialization
	private bool start  = true, end = false;
	private float lasttime = 0;
	void Start () {
		lasttime = 0;

		//Debug.Log (GameManager.Instance.curTimes);
		/*if(GameManager.Instance.curTimes>1 || !GameManager.Instance.isCutScene )//Time.time - lasttime > 30
		{
			Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = Player.transform;
			start = false;
			GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = true;
		}*/

		lasttime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevel == 3 && GameManager.Instance.isCutScene) 
		{
			//Debug.Log(Mathf.Abs (Camera.main.gameObject.transform.position.x - transform.position.x)+"lala");
			if (start && Mathf.Abs (Camera.main.gameObject.transform.position.x - transform.position.x) <= 0.01f) 
			{
				lasttime = Time.time;

				start = false;
				end = true;
			}
				

			if (end && Time.time - lasttime > 1f) 
			{
				Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = Player.transform;
				if(Mathf.Abs (Camera.main.gameObject.transform.position.x - GameManager.Instance.player.transform.position.x) <= 0.01f)
				{
					GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = true;	
					end = false;
				}

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
