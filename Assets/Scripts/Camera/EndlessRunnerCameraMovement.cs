using UnityEngine;
using System.Collections;

public class EndlessRunnerCameraMovement : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + 5, this.transform.position.y, this.transform.position.z);
	}
}
