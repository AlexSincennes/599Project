using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnDist = 15f;

	private float travelDist = 0f;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		Spawn (0f);
		lastPosition = transform.position;
	}

	void Update(){
		travelDist += transform.position.x - lastPosition.x;
		//Spawn a level block after distance traveled >= spawnDistance;
		if (travelDist >= spawnDist) {
			float offset = travelDist - spawnDist;
			Spawn (offset);
			travelDist = 0f;
		} else {
			lastPosition = transform.position;
		}
	}

	void Spawn(float offset){
		Vector3 spawnPos = transform.position - new Vector3(offset, 0, 0);
		Instantiate(obj[Random.Range(0, obj.Length)], spawnPos, Quaternion.identity);
	}
}
