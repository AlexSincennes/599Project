using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	 
	public int firstObjectIndex = 0;	//The first object to be spawned
	public GameObject[] obj;
	public float[] weights;

	private int objIndex;
	private bool spawned = false;
	private float spawnDist = 0f;	//Distance to travel until spawning object
	private float genDist = 0f;		//Distance to travel until generating new object
	private float travelDist = 0f;	//Distance traveled since last reset
	private float xOffset;
	private float yOffset = 0f;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start (){ 
		objIndex = firstObjectIndex;
		Spawn (0f);
		spawned = true;
		travelDist = 0f;
		lastPosition = transform.position;
	}

	void Update(){
		travelDist += transform.position.x - lastPosition.x;
		//If the last thing that happened was spawning 
		if (spawned) {
			if(travelDist >= genDist){
				xOffset = genDist - travelDist;
				objIndex = RandFuncs.Sample (weights);
				spawnDist = obj[objIndex].GetComponent<PrefabLength>().Length / 2.0f;
				spawned = false;
				travelDist = -xOffset;
			}
		} else {
			//Spawn a level block after distance traveled >= spawnDistance;
			if (travelDist >= spawnDist) {
				xOffset = spawnDist - travelDist;
				Spawn (xOffset);
				spawned = true;
				travelDist = -xOffset;
			}
		}
		lastPosition = transform.position;
	}

	void Spawn(float xOffset){
		Vector3 spawnPos = transform.position + new Vector3(xOffset, yOffset, 0);
		Instantiate(obj[objIndex], spawnPos, Quaternion.identity);
		//Set the genDist so that a new object is "generated" after traveling half the length of the spawned prefab
		genDist = obj[objIndex].GetComponent<PrefabLength>().Length / 2.0f;
	}
}
