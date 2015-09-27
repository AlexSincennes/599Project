using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public Transform spawnpoint;
	public GameObject spawn;
	// Use this for initialization
	void Start () {
		//if (spawnpoint == null)
			//spawnpoint = GameObject.FindGameObjectWithTag ("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			spawnpoint.position = transform.position;
			spawn.transform.position = transform.position;
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
}
