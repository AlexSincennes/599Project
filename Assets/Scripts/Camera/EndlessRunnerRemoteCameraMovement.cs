using UnityEngine;
using System.Collections;

public class EndlessRunnerRemoteCameraMovement : MonoBehaviour {

	public Transform follow;

	private Vector3 velocity = Vector3.zero;

	void Start(){
		//audioListener = this.GetComponentInChildren<AudioListener> ();
		//remoteDisplayManagerScript = remoteDisplayManager.GetComponent<Google.Cast.RemoteDisplay.CastRemoteDisplayManager>();
	}

	// Update is called once per frame
	void Update () {
		/*
		if (remoteDisplayManagerScript.IsCasting() && audioListener.enabled) {
			audioListener.enabled = false;
		} else if (!audioListener.enabled) {
			audioListener.enabled = true;
		}
		*/
		if (follow == null)
			follow = GameObject.FindGameObjectWithTag("Ghost").transform;
		transform.position = new Vector3 (follow.position.x + 5.0f, follow.position.y + 2.0f, this.transform.position.z);
		//transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (follow.position.x + 5.0f, follow.position.y + 2.0f, this.transform.position.z), ref velocity, 0.05f);
	}
}
