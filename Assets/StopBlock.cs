using UnityEngine;
using System.Collections;

public class StopBlock : MonoBehaviour {
	private GameObject obj;
	private int temp;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (temp == 1) {
			obj.GetComponentInChildren<RaycastCharacterController2D>().movement.walkSpeed = 0.0f;
			obj.GetComponentInChildren<RaycastCharacterController2D>().movement.runSpeed = 0.0f;
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag == "Player") {
			obj = other.gameObject;
			temp = 1;
		}
	}
	void OnCollisionExit2D(Collision2D other){
		if (other.collider.tag == "Player") {
			temp = 0;
		}
	}
}
