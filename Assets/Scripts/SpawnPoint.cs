using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject player;
	public Transform spawnpoint;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		player.transform.position = spawnpoint.position;
	}
}
