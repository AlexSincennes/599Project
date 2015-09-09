using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour
{	
	public OphionRaycastCharacterController controller;

	// Use this for initialization
	void Start () {
	
	}
	
	/// <summary>
	/// Switches the state of the shield if possible (equipped->unequipped and vice-versa).
	/// </summary>
	/// <returns><c>true</c>, if state was switched <c>false</c> otherwise.</returns>
	public bool ShieldStateSwitch () {
		// define what character can and can't do based on shield state
		if(controller.ledgeHanging.canLedgeHang == true) {
			if(CanEquipShield()) {
				controller.ledgeHanging.canLedgeHang = false;
				controller.climbing.allowClimbing = false;
				Debug.Log("Equipped shield.");
				return true;
			}
			else
				return false;
		}
		else {
			if(CanEquipShield()) {
				controller.ledgeHanging.canLedgeHang = true;
				controller.climbing.allowClimbing = true;
				Debug.Log("Unequipped shield.");
				return true;
			}
			else
				return false;
		}

	}

	private bool CanEquipShield () {
		return !controller.IsLedgeHanging && !controller.StartedClimbing;
	}
}
