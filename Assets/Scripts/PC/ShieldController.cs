using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {

	public OphionCharacterInput charinput;
	public RaycastCharacterController2D controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// define what character can and can't do based on shield state
		if(charinput.shieldEquipped && !controller.IsLedgeHanging) {
			controller.ledgeHanging.canLedgeHang = false;
		} else {
			controller.ledgeHanging.canLedgeHang = true;
		}
	}
}
