using UnityEngine;
using System.Collections;

public class BackgroundScrollerScript : MonoBehaviour {
	public float speed = 0f;
	public static BackgroundScrollerScript current;

	public GhostMovement Ghost;

	float pos = 0;
	// Use this for initialization
	void Start () {
		current = this;
		if(GameManagerRG.Instance.ghost != null)
			Ghost = GameManagerRG.Instance.ghost.GetComponent<GhostMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Ghost == null || Ghost.movementSpeedX != 0) && Time.timeScale != 0) {
			pos += speed;
		}
		if (pos > 1.0f) {
			pos -= 1;
		}
		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);
	}
}
