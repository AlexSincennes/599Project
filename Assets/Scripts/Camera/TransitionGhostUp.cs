using UnityEngine;
using System.Collections;

public class TransitionGhostUp : MonoBehaviour {

	private float startY;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			startY = other.transform.position.y;
			other.GetComponent<GhostMovement> ().movementSpeedX = 0.0f;
			other.GetComponent<GhostMovement> ().movementSpeedY = other.GetComponent<GhostMovement>().currentMovementSpeed * 0.5f;
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
			//Reset the ghost's direction and speed
			other.GetComponent<GhostMovement> ().movementSpeedY = 0.0f;
			other.GetComponent<GhostMovement> ().movementSpeedX = other.GetComponent<GhostMovement>().currentMovementSpeed;
		} else {
		}
	}
}
