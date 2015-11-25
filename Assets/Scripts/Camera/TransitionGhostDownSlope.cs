using UnityEngine;
using System.Collections;

public class TransitionGhostDownSlope : MonoBehaviour {

	private float startY;
	private float transAngleRads;	//The angle at which the transition slopes
	private GhostMovement ghostMovement;

	void Start(){
		//Calculate the angle of descent in radians
		transAngleRads = Mathf.Atan2 (-transform.parent.GetComponentInParent<PrefabAttributes>().Height, transform.parent.GetComponentInParent<PrefabAttributes>().Length);
		ghostMovement = GameObject.FindGameObjectWithTag ("Ghost").GetComponent<GhostMovement> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			startY = other.transform.position.y;
			ghostMovement.movementSpeedX = Mathf.Cos (transAngleRads) * ghostMovement.currentMovementSpeed;
			ghostMovement.movementSpeedY = Mathf.Sin (transAngleRads) * ghostMovement.currentMovementSpeed;
		} else {
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			float yOffset = startY - transform.parent.GetComponentInParent<PrefabAttributes>().Height - other.transform.position.y;
			if (yOffset != 0.0f) {
				other.transform.Translate(Vector3.up * yOffset);
			}
			//Increase the current movementspeed
			if(ghostMovement.currentMovementSpeed < ghostMovement.maxMovementSpeed){
				ghostMovement.currentMovementSpeed += ghostMovement.acceleration;
			}
			//Reset the ghost's direction and speed
			ghostMovement.movementSpeedY = 0.0f;
			ghostMovement.movementSpeedX = ghostMovement.currentMovementSpeed;
		} else {
		}
	}
}
