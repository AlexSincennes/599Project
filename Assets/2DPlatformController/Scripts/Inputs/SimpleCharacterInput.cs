using UnityEngine;
using System.Collections;

/// <summary>
/// A simple character input. Arrows to move, left SHIFT to run, SPACE to jump.
/// </summary>
public class SimpleCharacterInput : RaycastCharacterInput
{

	/// <summary>
	/// IF true always run.
	/// </summary>
	public bool alwaysRun;

	/// <summary>
	/// If true dropping from a passthrough platform requires user to press down and then jump.
	/// </summary>
	public bool jumpAndDownForDrop;
	public bool jump = false;

	private int movingDirection;


	void Update ()
	{
		if (Input.GetKey(KeyCode.R)) {
			//GameManager.Instance.deathPos = GameObject.Find("HeroCharacter").transform.position;
			if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;

			Application.LoadLevel(0);
		}
		
		jumpButtonHeld = false;
		if ((check == 0)||(check == 2)) {
			DashButtonDown = false;
		}
		jumpButtonDown = false;
		dropFromPlatform = false;
		x = 0;
		y = 0;

		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)|| true) {
			x = 0.5f;
			movingDirection = 1;
		} else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
			x = -0.5f;
			movingDirection = -1;
		} else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)){
			x = movingDirection / 2.0f;
		}
	
		// Shift to run
		if (alwaysRun || Input.GetKey(KeyCode.LeftShift)) {
			x *= 2;
		}
		if (shieldT == true && transform.GetComponentInChildren<HitBox>().bashManager.curMeter>0) {
			if ((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.UpArrow)) || (Input.GetKey (KeyCode.DownArrow))) {
				if (Input.GetKeyUp (KeyCode.Z)) {
					//print("yolo");
					DashButtonDown = true;
					transform.GetComponentInChildren<HitBox>().bashManager.UpdateBashMeter(-10.0f);
				}
			}
		}
		if (Input.GetKey(KeyCode.W) ) {
			y = 1;
		} else if (Input.GetKey(KeyCode.S) ) {
			y = -1;
			if (!jumpAndDownForDrop) dropFromPlatform = true;
		}
		
		if ( jump) {//Input.GetKey(KeyCode.Space)
			jumpButtonHeld = true;

			if (jump) {//Input.GetKeyDown(KeyCode.Space)
				if (jumpAndDownForDrop && Input.GetKey(KeyCode.S)) {
					dropFromPlatform = true;
				} else {
					jumpButtonDown = true;	
				}
				swimButtonDown = true;	
				jump = false;
			} else {
				jumpButtonDown = false;		
				swimButtonDown = false;
			}
			jump = false;
		} else {
			jumpButtonDown = false;
			swimButtonDown = false;
		}
	}	
}
