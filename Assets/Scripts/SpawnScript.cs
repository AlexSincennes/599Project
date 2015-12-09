using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	 
	public int firstObjectIndex = 0;	//The first object to be spawned
	public float milestoneFreq = 0f;	//The frequency at which a milestone(transition) should spawn
										// set to 0 to not have spawn any transitions
	public float startSpawnerDist = 355f;	//The world x position at which to start the spawner
	public GameObject[] basicObj;
	public float[] basicWeights;
	public GameObject[] transObj;
	public float[] transWeights;
	public Transform ghostTransform;
	private float initialGhostYPos;
	private float lastGhostYPos;
	private float currentGhostYPos;

	private int objIndex;
	private bool spawned = false;	//False when a prefab index has been generated but not yet spawned
	private bool transition = false;//False while the next prefab to be generated is not a transition
	private bool started = false;	//Used by the tutorial level to determine when the spawner has started spawning
	private float spawnDist = 0f;	//Distance to travel until spawning object
	private float genDist = 0f;		//Distance to travel until generating new object
	private float travelDist = 0f;	//Distance traveled since last reset
	private float totalTravelDist = 0f;
	private float xOffset = 0f;			//Offset x-position used for perfect placement of prefabs
	private float yOffset = 0f;		//Offset y-position used for placing prefabs at the right height
	private float milestoneXOffset; //Offset x-position used for perfect calculation of next milestone
	private float nextMilestone;	//Location at which to spawn a milestone transition
	private Vector3 lastPosition;
	
	private GameObject prefabContainer;

	// Use this for initialization
	void Start (){
		prefabContainer = new GameObject("PrefabContainer");
		//Delay initializing the spawner if the loaded level is the tutorial level
		if (Application.loadedLevel != 2) {
			InitSpawner();
		}
	}

	void Update(){
		if (ghostTransform == null) {
			ghostTransform = GameManagerRG.Instance.ghost.transform;
		}
		totalTravelDist += transform.position.x - lastPosition.x;
		if (Application.loadedLevel != 2 || totalTravelDist > startSpawnerDist) {
			if(!started && Application.loadedLevel == 2){
				xOffset = startSpawnerDist - totalTravelDist;
				InitSpawner();
			}
			travelDist += transform.position.x - lastPosition.x;
			if (yOffset != 0) {
				//Get the current y position of the ghost, compare it to the inital y position
				currentGhostYPos = ghostTransform.position.y;
				yOffset += lastGhostYPos - currentGhostYPos;
				lastGhostYPos = currentGhostYPos;
			}
			//If the last thing that happened was spawning 
			if (spawned) {
				if (travelDist >= genDist) {
					xOffset = genDist - travelDist;					
					if (nextMilestone > 0 && totalTravelDist >= nextMilestone) {
						//Generate an index of a transitional prefab
						objIndex = RandFuncs.Sample (transWeights);
						//Get the length of the transition prefab
						float transPrefabLength = transObj [objIndex].GetComponent<PrefabAttributes> ().Length;
						//Divide the length of the prefab in half to spawn after traveling that distance
						spawnDist = transPrefabLength / 2.0f;

						//Set the distance at which the next milestone should spawn
						milestoneXOffset = nextMilestone - totalTravelDist;
						nextMilestone = totalTravelDist + milestoneFreq + milestoneXOffset + transPrefabLength;
						transition = true;
					} else {
						//Generate a random prefab index to spawn later
						objIndex = RandFuncs.Sample (basicWeights);
						//Divide the length of the prefab in half to spawn after traveling that distance
						spawnDist = basicObj [objIndex].GetComponent<PrefabAttributes> ().Length / 2.0f;
					}
					spawned = false;
					travelDist = -xOffset;
				}
			} else {
				//Spawn a level block after distance traveled >= spawnDistance;
				if (travelDist >= spawnDist) {
					xOffset = spawnDist - travelDist;
					if (transition) {
						//Get the attributes of the transition prefab
						PrefabAttributes transPrefabAttributes = transObj [objIndex].GetComponent<PrefabAttributes> ();
						//Spawn the transition object
						Spawn (transObj, objIndex, xOffset);
						transition = false;
						if (transPrefabAttributes.UpTransition) {
							yOffset = transPrefabAttributes.Height;
						} else {
							yOffset = -transPrefabAttributes.Height;
						}
						//Capture the initial y position of the ghost to calculate the yOffset for spawning
						initialGhostYPos = ghostTransform.position.y;
						lastGhostYPos = initialGhostYPos;
					} else {
						Spawn (basicObj, objIndex, xOffset);
					}
					spawned = true;
					travelDist = -xOffset;
				}
			}
		}
		lastPosition = transform.position;
	}

	void InitSpawner(){
		//Spawn the first prefab
		Spawn (basicObj, firstObjectIndex, xOffset);
		spawned = true;
		travelDist = -xOffset;
		nextMilestone = totalTravelDist + milestoneFreq;
		lastPosition = transform.position;
		started = true;
	}

	int counter =0;
	int sumChilds = 0;
	GameObject temp;
	void Spawn(GameObject[] obj, int spawnIndex, float spawnXOffset){
		counter = 0;
		Vector3 spawnPos = transform.position + new Vector3(spawnXOffset, yOffset, 0);
		Transform prefabTransform = prefabContainer.transform.FindChild(obj[spawnIndex].name + "(Clone)");
		if (prefabTransform != null && !prefabTransform.gameObject.active)
		{
			GameObject prefab = prefabTransform.gameObject;

			prefab.transform.position = spawnPos;
			// TODO(sot): reset prefab
			prefab.SetActive(true);

			sumChilds = prefab.transform.childCount;
			while(counter < sumChilds)
			{
				temp = prefab.transform.GetChild(counter).gameObject;
				if(!temp.activeInHierarchy)
				{
					temp.SetActive(true);
				}
				counter ++;
			}

			//Debug.Log ("DEBUG TIM");
		}
		else
		{
			GameObject go = (GameObject)Instantiate(obj[spawnIndex], spawnPos, Quaternion.identity);
			go.transform.parent = prefabContainer.transform;
		}
		//Set the genDist so that a new object is "generated" after traveling half the length of the spawned prefab
		genDist = obj[spawnIndex].GetComponent<PrefabAttributes>().Length / 2.0f;
	}

	public bool isStarted(){
		return started;
	}
}
