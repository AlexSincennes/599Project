using UnityEngine;
using System.Collections;

public class TransitionGhostUp : MonoBehaviour {

	private float startY;
	private GhostMovement ghostMovement;

	void Start(){
		ghostMovement = GameObject.FindGameObjectWithTag ("Ghost").GetComponent<GhostMovement> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			startY = other.transform.position.y;
			ghostMovement.movementSpeedX = 0.0f;
			ghostMovement.movementSpeedY = ghostMovement.currentMovementSpeed * 0.5f;
			float xOffset = transform.position.x - other.transform.position.x;
			other.transform.Translate(Vector3.right * xOffset);
		} else {
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			float yOffset = startY + transform.parent.GetComponentInParent<PrefabAttributes>().Height - other.transform.position.y;
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
		}
	}
}
