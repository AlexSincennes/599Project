using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public GameObject spawner;	//This needs to be here so that the transitions can adjust the spawner's offsets
	public GameObject player;
	public float startMovementSpeed = 7f;
	public float maxMovementSpeed = 30f;
	public float currentMovementSpeed;
	public float movementSpeedX;
	public float movementSpeedY = 0f;

	void Start(){
		player.GetComponent<RaycastCharacterController2D>().movement.walkSpeed = startMovementSpeed;
		currentMovementSpeed = startMovementSpeed;
		movementSpeedY = 0f;
		movementSpeedX = currentMovementSpeed;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * movementSpeedX * Time.deltaTime + Vector3.up * movementSpeedY * Time.deltaTime);
		//Check if the player is too behind or ahead of the ghost.  Adjust speed of the player as necessary
		if (player.transform.position.x < this.transform.position.x) {

		}
	}
}
