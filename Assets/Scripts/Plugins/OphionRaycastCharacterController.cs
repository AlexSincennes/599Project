﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OphionRaycastCharacterController : RaycastCharacterController {
	/// <summary>
	/// The character input that controls this character.
	/// </summary>
	public OphionRaycastCharacterInput ophionInput;

	public bool debug;
	public Text debugText;

	// Use this for initialization
	void Start () {
		if (!debug) {
			debugText.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		DoShield ();
	}
	
	//Shield
	public void DoShield(){
		if (debug) {
			debugText.text = "Shield Equipped: " + ophionInput.shieldButtonToggle;
		}
		if (ophionInput.shieldButtonToggle) {
		
		}
	}
}