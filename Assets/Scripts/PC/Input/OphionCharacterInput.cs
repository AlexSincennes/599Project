using UnityEngine;
using System.Collections;

/// <summary>
/// A simple character input. Arrows to move, left SHIFT to run, SPACE to jump.
/// </summary>
public class OphionCharacterInput : RaycastCharacterInput
{
	public ShieldController shieldController;
	public GameObject avatar;
	
	/// <summary>
	/// IF true always run.
	/// </summary>
	public bool alwaysRun;
	
	public bool shieldEquipped;
	
	/// <summary>
	/// If true dropping from a passthrough platform requires user to press down and then jump.
	/// </summary>
	public bool jumpAndDownForDrop;
	
	private int movingDirection;
	
	void Update ()
	{
		
		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(0);
		}
		
		jumpButtonHeld = false;
		jumpButtonDown = false;
		dropFromPlatform = false;
		x = 0;
		y = 0;
		
		if (Input.GetKey("right") && !Input.GetKey("left")) {
			x = 0.5f;
			movingDirection = 1;
		} else if (Input.GetKey("left") && !Input.GetKey("right")) {
			x = -0.5f;
			movingDirection = -1;
		} else if (Input.GetKey("right") && Input.GetKey("left")){
			x = movingDirection / 2.0f;
		}
		
		// Shift to run
		if (alwaysRun || Input.GetKey(KeyCode.LeftShift)) {
			x *= 2;
		}
		
		if (Input.GetKey("up") ) {
			y = 1;
		} else if (Input.GetKey("down") ) {
			y = -1;
			if (!jumpAndDownForDrop) dropFromPlatform = true;
		}
		
		if (Input.GetKey(KeyCode.Space) ) {
			jumpButtonHeld = true;
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (jumpAndDownForDrop && Input.GetKey("down")) {
					dropFromPlatform = true;
				} else {
					jumpButtonDown = true;	
				}
				swimButtonDown = true;	
			} else {
				jumpButtonDown = false;		
				swimButtonDown = false;
			}
		} else {
			jumpButtonDown = false;
			swimButtonDown = false;
		}

		if (Input.GetKeyDown (KeyCode.P) ) {
			if(shieldController.ShieldStateSwitch())
				shieldEquipped = !shieldEquipped;
			Material mat = avatar.GetComponent<SkinnedMeshRenderer>().material;
			if(shieldEquipped) {
				mat.color = new Color(0.8f,0.0f,0.0f);
			}
			else
			{
				mat.color = new Color(0.54f,0.64f,0.86f);
			}
		}
	}
	
}

