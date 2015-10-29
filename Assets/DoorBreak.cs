using UnityEngine;
using System.Collections;

public class DoorBreak : Platform2D {
	private GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if(other.gameObject.GetComponentInChildren<RaycastCharacterController2D>().characterInput.check != 1){
				Destroy(this.gameObject);
			}
		}
	}
	override public void DoAction(RaycastCollider2D collider, RaycastCharacterController2D character) {
		print (character.characterInput.check);
		if (character.characterInput.check == 0) {
			Destroy(this.gameObject);
		}
	}
}
