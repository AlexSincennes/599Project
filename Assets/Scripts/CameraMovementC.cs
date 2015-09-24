using UnityEngine;
using System.Collections;

public class CameraMovementC : MonoBehaviour {
	public Transform target;
	public float distance ;
	// Use this for initialization
	void Start () {
		if (target == null) 
		{
			target = GameObject.Find("HeroCharacter").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position,new Vector3 (target.position.x,target.position.y+5,target.position.z -distance),Time.deltaTime*20); 

	}
}
