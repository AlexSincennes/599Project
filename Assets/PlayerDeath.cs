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
		if (other.gameObject.tag == "Player") 
		{
			Application.LoadLevel(Application.loadedLevel);
			GameManager.Instance.deathPos = other.transform.parent.position;
			GameManager.Instance.curTimes++;
		}
			

	}
}
