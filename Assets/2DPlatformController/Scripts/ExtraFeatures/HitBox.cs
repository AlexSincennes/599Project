using UnityEngine;
using System.Collections;

/// <summary>
/// A hit box takes damage and passes it to a health component for processing.
/// This allows you to easily move the damage points or alternatively attach
/// them to transforms.
///
///	A hit box can also be used to collect items. Although at the moment the collect method
/// doesn't do anything. You could sue this to grant powers, increment counters, etc.
/// </summary>
public class HitBox : MonoBehaviour {

	public SimpleHealth simplehealth;

	public virtual void Damage(int amount) {
		//simplehealth.Damage(amount);
		//Application.LoadLevel(Application.loadedLevel);
		
		//GameManager.Instance.deathPos = transform.parent.position;
		//GameManager.Instance.curTimes++;

		GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
	}

	public virtual void Collect (Collectable collectable) {

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Enemy") 
		{
			//Application.LoadLevel(Application.loadedLevel);
			//GameManager.Instance.deathPos = transform.parent.position;
			//GameManager.Instance.curTimes++;

			GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
		}
		
		
	}


}
