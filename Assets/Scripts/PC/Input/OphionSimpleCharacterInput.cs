using UnityEngine;
using System.Collections;

public class OphionSimpleCharacterInput : OphionRaycastCharacterInput {

	void Update ()
	{
		//Shield Input
		//Toggle equip
		if(Input.GetKeyDown(KeyCode.P))
		{
			shieldButtonToggle = !shieldButtonToggle;
		}
		/*
		//Hold to equip/Release to Unequip
		if(Input.GetKeyDown(KeyCode.P))
		{
			shieldButtonToggle = true;
		}
		if(Input.GetKeyUp(KeyCode.P))
		{
			shieldButtonToggle = false;
		}
		*/
	}
}
