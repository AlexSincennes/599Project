using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	public Transform spawnpoint;
	public GameObject player;
	public GameObject spawn;
	// Use this for initialization
	void Start () {
		//if (spawnpoint == null)
		//	spawnpoint = GameObject.FindGameObjectWithTag ("Spawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") {
			//player = other.gameObject;
			//if(spawnpoint!=null)
				//spawn = spawnpoint.position;
			//DontDestroyOnLoad(spawn);
			Application.LoadLevel(Application.loadedLevel);
			//spawnpoint = GameObject.FindGameObjectWithTag ("Spawn");
			//if (spawnpoint != null) {
				//spawnpoint.transform.position = spawn;
				//player.transform.position = spawnpoint.position;
			//}
		}
	}
}
