using UnityEngine;
using System.Collections;

public class CameraTut : MonoBehaviour {
	private Vector3 velocity = Vector3.zero;
	public Transform follow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3 (follow.position.x + 5.0f, follow.position.y + 2.0f, this.transform.position.z);
		transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (follow.position.x + 5.0f, this.transform.position.y, this.transform.position.z), ref velocity, 0.05f);

	}
}
