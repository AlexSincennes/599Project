using UnityEngine;
using System.Collections;

public class TransitionGhostDownSlope : MonoBehaviour {

	private float startY;
	private float transAngleRads;	//The angle at which the transition slopes

	void Start(){
		//Calculate the angle of descent in radians
		transAngleRads = Mathf.Atan2 (-transform.parent.GetComponentInParent<PrefabAttributes>().Height, transform.parent.GetComponentInParent<PrefabAttributes>().Length);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			startY = other.transform.position.y;
			other.GetComponent<GhostMovement> ().movementSpeedX = Mathf.Cos (transAngleRads) * other.GetComponent<GhostMovement> ().currentMovementSpeed;
			other.GetComponent<GhostMovement> ().movementSpeedY = Mathf.Sin (transAngleRads) * other.GetComponent<GhostMovement> ().currentMovementSpeed;
		} else {
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			float yOffset = startY - transform.parent.GetComponentInParent<PrefabAttributes>().Height - other.transform.position.y;
			if (yOffset != 0.0f) {
				other.transform.Translate(Vector3.up * yOffset);
			}
			//Reset the ghost's direction and speed
			other.GetComponent<GhostMovement> ().movementSpeedY = 0.0f;
			other.GetComponent<GhostMovement> ().movementSpeedX = other.GetComponent<GhostMovement>().currentMovementSpeed;
		} else {
		}
	}
}
