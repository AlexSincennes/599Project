using UnityEngine;
using System.Collections;

public class SlowBlock : Platform2D {
	private RaycastCharacterController2D obj;
	public float delay;
	public float SlowSpeed;
	private float Speed;
	private int temp;
	private float t;
	private float r;
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
				temp = 2;
			}
		} else if (temp == 2) {
			if(Time.time > r){
				obj.movement.walkSpeed = Speed;
				obj.movement.runSpeed = Speed;
				temp = 0;
			}
		}
	}
	override public void DoAction(RaycastCollider2D collider, RaycastCharacterController2D character) {
		temp = 1;
		obj = character;
		Speed = character.movement.runSpeed;
		Destroy (this.GetComponent<BoxCollider2D> ());
	}
}
