using UnityEngine;
using System.Collections;

public class StopBlock : MonoBehaviour {
	public Sprite boxEmpty;
	private RaycastCharacterController2D obj;
	private GhostMovement ghost;
	public float delay;
	public float SlowSpeed;
	private float Speed;
	private int temp;
	private float t;
	private float r;
	private float storedSpeed;
	// Use this for initialization
	void Start () {
		obj = null;
		temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (temp == 1) {
			t = Time.time;
			r = t + delay;
			if (obj != null) {
				obj.movement.walkSpeed = SlowSpeed;
				obj.movement.runSpeed = SlowSpeed;
				ghost.playerSlowed = true;
				temp = 2;
			}
		} else if (temp == 2) {
			if(Time.time > 2.0){
				//Destroy (this.GetComponent<SpriteRenderer> ());
			}
			if(Time.time > r){
				//Destroy(this.gameObject);
				ghost.playerSlowed = false;
				obj.movement.walkSpeed = storedSpeed;
				obj.movement.runSpeed = storedSpeed;
				temp = 0;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			temp = 1;
			obj = other.gameObject.GetComponentInParent<RaycastCharacterController2D>();
			Destroy (this.GetComponent<BoxCollider2D> ());
			this.GetComponent<SpriteRenderer>().sprite = boxEmpty;

			storedSpeed = obj.movement.walkSpeed;
		}
		ghost = GameManagerRG.Instance.ghost.GetComponent<GhostMovement>();//GameObject.FindGameObjectWithTag ("Ghost")
	}
}
