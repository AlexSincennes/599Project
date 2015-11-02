using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	 
	public GameObject[] obj;
	public float[] weights;

	private int objIndex;
	private bool spawned = false;
	private float spawnDist = 0f;	//Distance to travel until spawning object
	private float genDist = 0f;		//Distance to travel until generating new object
	private float travelDist = 0f;	//Distance traveled since last reset
	private float offset;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		Spawn (0f);
		lastPosition = transform.position;
	}

	void Update(){
		travelDist += transform.position.x - lastPosition.x;
		//If the last thing that happened was spawning 
		if (spawned) {
			if(travelDist >= genDist){
				offset = travelDist - genDist;
				objIndex = RandFuncs.Sample (weights);
				spawnDist = obj[objIndex].GetComponent<PrefabLength>().Length / 2.0f;
				spawned = false;
				travelDist = offset;
			} else {
				lastPosition = transform.position;
			}
		} else {
			//Spawn a level block after distance traveled >= spawnDistance;
			if (travelDist >= spawnDist) {
				offset = travelDist - spawnDist;
				Spawn (offset);
				spawned = true;
				travelDist = 0f;
			} else {
				lastPosition = transform.position;
			}
		}
	}

	void Spawn(float offset){
		Vector3 spawnPos = transform.position - new Vector3(offset, 0, 0);
		Instantiate(obj[objIndex], spawnPos, Quaternion.identity);
		travelDist = 0f;
		//Set the genDist so that a new object is "generated" after traveling half the length of the spawned prefab
		genDist = obj [objIndex].GetComponent<PrefabLength> ().Length / 2.0f;
	}
}
