using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class for character input, extend this to provide your own input.
/// </summary>
public abstract class OphionRaycastCharacterInput : RaycastCharacterInput {

	/// <summary>
	/// Was the shield button pressed this frame.
	/// </summary>
	virtual public bool shieldButtonToggle{get; protected set;}
}
