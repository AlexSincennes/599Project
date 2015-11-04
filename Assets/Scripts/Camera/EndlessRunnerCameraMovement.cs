using UnityEngine;
using System.Collections;

public class EndlessRunnerCameraMovement : MonoBehaviour {
	private Vector3 velocity = Vector3.zero;
	public Transform player;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (player.position.x + 5, this.transform.position.y, this.transform.position.z), ref velocity, 0.05f);
	}
}
