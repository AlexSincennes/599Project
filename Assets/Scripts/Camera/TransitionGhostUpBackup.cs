using UnityEngine;
using System.Collections;

public class TransitionGhostUpBackup : MonoBehaviour {

	public int GhostDetectionChildIndex = 4;
	public float xOffset;
	public float x;

	private Transform ghostDetectionTransform;
	private float startY;

	void Start(){
		ghostDetectionTransform = transform.parent.GetChild(GhostDetectionChildIndex).gameObject.transform;
		x = ghostDetectionTransform.position.x;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Ghost")) {
			startY = other.transform.position.y;
			other.GetComponent<GhostMovement> ().movementSpeedX = 0.0f;
			xOffset = other.transform.position.x - ghostDetectionTransform.position.x;
			other.transform.Translate(Vector3.left * xOffset);
		} else {
		}
	}
}
