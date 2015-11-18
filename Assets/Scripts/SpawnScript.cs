using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	 
	public int firstObjectIndex = 0;	//The first object to be spawned
	public float milestoneFreq = 0f;	//The frequency at which a milestone(transition) should spawn
										// set to 0 to not have spawn any transitions
	public GameObject[] basicObj;
	public float[] basicWeights;
	public GameObject[] transObj;
	public float[] transWeights;
	public Transform follow;
	public Transform ghostTransform;
	private float initialGhostYPos;
	private float lastGhostYPos;
	private float currentGhostYPos;

	private int objIndex;
	private bool spawned = false;	//False when a prefab index has been generated but not yet spawned
	private bool transition = false;//False while the next prefab to be generated is not a transition
	private float spawnDist = 0f;	//Distance to travel until spawning object
	private float genDist = 0f;		//Distance to travel until generating new object
	private float travelDist = 0f;	//Distance traveled since last reset
	private float xOffset;			//Offset x-position used for perfect placement of prefabs
	public float yOffset = 0f;		//Offset y-position used for placing prefabs at the right height
	private float milestoneXOffset; //Offset x-position used for perfect calculation of next milestone
	public float totalTravelDist = 0f;
	public float nextMilestone;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start (){ 
		InitSpawner();
	}

	void Update(){
		if (ghostTransform == null) {
			ghostTransform = GameObject.FindGameObjectWithTag ("Ghost").transform;

		}
		/*if (follow == null)
			follow = GameObject.FindGameObjectWithTag ("Camera").transform;
		transform.position = new Vector3 (follow.position.x + 30.0f, follow.position.y - 2.5f, this.transform.position.z);
*/
		travelDist += transform.position.x - lastPosition.x;
		totalTravelDist += transform.position.x - lastPosition.x;

		if(yOffset != 0){
			//Get the current y position of the ghost, compare it to the inital y position
			currentGhostYPos = ghostTransform.position.y;
			yOffset += lastGhostYPos - currentGhostYPos;
			lastGhostYPos = currentGhostYPos;
		}
		//If the last thing that happened was spawning 
		if (spawned) {
			if(travelDist >= genDist){
				xOffset = genDist - travelDist;
				if(nextMilestone > 0 && totalTravelDist >= nextMilestone){
					//Generate an index of a transitional prefab
					objIndex = RandFuncs.Sample (transWeights);
					//Divide the length of the prefab in half to spawn after traveling that distance
					spawnDist = transObj[objIndex].GetComponent<PrefabAttributes>().Length / 2.0f;

					//Set the distance at which the next milestone should spawn
					milestoneXOffset = nextMilestone - totalTravelDist;
					nextMilestone = totalTravelDist + milestoneFreq + milestoneXOffset + transObj[objIndex].GetComponent<PrefabAttributes>().Length;
					transition = true;
				}
				else{
					//Generate a random prefab index to spawn later
					objIndex = RandFuncs.Sample (basicWeights);
					//Divide the length of the prefab in half to spawn after traveling that distance
					spawnDist = basicObj[objIndex].GetComponent<PrefabAttributes>().Length / 2.0f;
				}
				spawned = false;
				travelDist = -xOffset;
			}
		} else {
			//Spawn a level block after distance traveled >= spawnDistance;
			if (travelDist >= spawnDist) {
				xOffset = spawnDist - travelDist;
				if(transition){
					Spawn(transObj, objIndex, xOffset);
					transition = false;
					if(transObj[objIndex].GetComponent<PrefabAttributes>().UpTransition){
						yOffset = transObj[objIndex].GetComponent<PrefabAttributes>().Height;
					}
					else{
						yOffset = -transObj[objIndex].GetComponent<PrefabAttributes>().Height;
					}
					//Capture the initial y position of the ghost to calculate the yOffset for spawning
					initialGhostYPos = ghostTransform.position.y;
					lastGhostYPos = initialGhostYPos;
				}
				else{
					Spawn(basicObj, objIndex, xOffset);
				}
				spawned = true;
				travelDist = -xOffset;
			}
		}
		lastPosition = transform.position;
	}

	void InitSpawner(){
		objIndex = firstObjectIndex;
		//Spawn the first prefab
		Spawn(basicObj, objIndex, 0f);
		spawned = true;
		travelDist = 0f;
		nextMilestone = totalTravelDist + milestoneFreq;
		totalTravelDist = 35f;	//The spawner starts 35 units away from the player
		lastPosition = transform.position;
	}

	void Spawn(GameObject[] obj, int spawnIndex, float xOffset){
		Vector3 spawnPos = transform.position + new Vector3(xOffset, yOffset, 0);
		Instantiate(obj[spawnIndex], spawnPos, Quaternion.identity);
		//Set the genDist so that a new object is "generated" after traveling half the length of the spawned prefab
		genDist = obj[spawnIndex].GetComponent<PrefabAttributes>().Length / 2.0f;
	}
}
