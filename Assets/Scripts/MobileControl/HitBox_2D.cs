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
public class HitBox_2D : MonoBehaviour {

	//public SimpleHealth simplehealth;
	//public BashManager bashManager;

	public virtual void Damage(int amount) {
		//simplehealth.Damage(amount);
		//Debug.Log ("dada");
		Application.LoadLevel(Application.loadedLevel);
		
		//GameManager.Instance.deathPos = transform.parent.position;
		//if(Application.loadedLevel == 2)
		//GameManager.Instance.curTimes++;

		//GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
	}

	public virtual void Collect (Collectable collectable) {
		Debug.Log ("Collect "+ collectable.transform.parent.name+" !!!!!!!!!!");
		//bashManager.UpdateBashMeter (10.0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log (other.gameObject.tag );
		if (other.gameObject.tag == "Enemy") 
		{
			Application.LoadLevel(Application.loadedLevel);
			//GameManager.Instance.deathPos = transform.parent.position;
			//if(Application.loadedLevel == 2)
			//GameManager.Instance.curTimes++;

			//GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
		}
		
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log (other.gameObject.tag );
	}

	public void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
		//if(Application.loadedLevel == 2)
			//GameManager.Instance.curTimes++;
	}


}