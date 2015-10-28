using UnityEngine;
using System.Collections;

public class SlowBlock : MonoBehaviour {
	private GameObject obj;
	public float delay;
	public float SlowSpeed;
	private float Speed;
	private int temp;
	// Use this for initialization
	void Start () {
		obj = null;
		temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (temp == 1) {
			float t = Time.time;
			float r = t + delay;
			if(obj != null){
				if(Time.time < r){
					obj.GetComponentInChildren<RaycastCharacterController2D>().movement.walkSpeed = SlowSpeed;
					obj.GetComponentInChildren<RaycastCharacterController2D>().movement.runSpeed = SlowSpeed;
				}
				else{
					obj.GetComponentInChildren<RaycastCharacterController2D>().movement.walkSpeed = Speed;
					obj.GetComponentInChildren<RaycastCharacterController2D>().movement.runSpeed = Speed;
					temp = 0;
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
	if (other.CompareTag("Player")) {
			obj = other.gameObject;
			temp = 1;
			Speed = obj.GetComponentInChildren<RaycastCharacterController2D>().movement.runSpeed;
		}
	}
}
