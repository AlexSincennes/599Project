using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class for character input, extend this to provide your own input.
/// </summary>
public abstract class OphionRaycastCharacterInput : RaycastCharacterInput
{
	/// <summary>
	/// Was the shield equip button pressed this frame.
	/// </summary>
	virtual public bool shieldEquipButtonDown{get; protected set;}

	/// <summary>
	/// Was the block button pressed this frame.
	/// </summary>
	virtual public bool blockButtonDown{get; protected set; }
}
