using UnityEngine;
using System.Collections;

public class CharacterSimpleInput : MonoBehaviour {
	public float moveSpeed;
	float movement;
	// Use this for initialization
	void Start () {
		movement = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			movement -= moveSpeed*Time .deltaTime;
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			movement += moveSpeed*Time .deltaTime;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)||Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			movement = 0;
		}
		transform.Translate (new Vector3(movement,0,0));
	}
}
