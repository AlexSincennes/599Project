using UnityEngine;
using System.Collections;

public class EndlessRunnerCameraMovement : MonoBehaviour {

	public Transform follow;

	private Vector3 velocity = Vector3.zero;	

	//private Google.Cast.RemoteDisplay.CastRemoteDisplayManager remoteDisplayManager;
	//private Google.Cast.RemoteDisplay.CastRemoteDisplayManager remoteDisplayManagerScript;

	void Start(){
		//remoteDisplayManager = (Google.Cast.RemoteDisplay.CastRemoteDisplayManager)GameObject.FindObjectOfType(typeof(Google.Cast.RemoteDisplay.CastRemoteDisplayManager));
		//remoteDisplayManagerScript = remoteDisplayManager.GetComponent<Google.Cast.RemoteDisplay.CastRemoteDisplayManager>();
	}

	// Update is called once per frame
	void Update () {
		//if (remoteDisplayManagerScript.IsCasting()) {
		//} else if (!remoteDisplayManagerScript.IsCasting()) {
		//}

		if (follow == null)
			follow = GameObject.FindGameObjectWithTag("Ghost").transform;
		transform.position = new Vector3 (follow.position.x + 5.0f, follow.position.y + 2.0f, this.transform.position.z);
		//transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (follow.position.x + 5.0f, follow.position.y + 2.0f, this.transform.position.z), ref velocity, 0.05f);
	}
}
