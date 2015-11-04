using UnityEngine;
using System.Collections;

public class StopBlock : MonoBehaviour {
	public Sprite boxEmpty;
	private GameObject obj;
	public float delay;
	public float SlowSpeed;
	private float Speed;
	private int temp;
	private float t;
	private float r;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (temp == 1) {
			t = Time.time;
			r = t + delay;
			if (obj != null) {
				obj.GetComponentInParent<RaycastCharacterController2D>().movement.walkSpeed = SlowSpeed;
				obj.GetComponentInParent<RaycastCharacterController2D>().movement.runSpeed = SlowSpeed;
				temp = 2;
			}
		} else if (temp == 2) {
			if(Time.time > 2.0){
				//Destroy (this.GetComponent<SpriteRenderer> ());
			}
			if(Time.time > r){
				//Destroy(this.gameObject);
				obj.GetComponentInParent<RaycastCharacterController2D>().movement.walkSpeed = 10;
				obj.GetComponentInParent<RaycastCharacterController2D>().movement.runSpeed = 10;
				temp = 0;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			temp = 1;
			obj = other.gameObject;
			Destroy (this.GetComponent<BoxCollider2D> ());
			this.GetComponent<SpriteRenderer>().sprite = boxEmpty;
		}
	}
}
