using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour
{	
	public float deflectTime;
	public GameObject Bullet;
	public OphionRaycastCharacterInput ophionInput;

	private float lastDeflectTime = 0;
	private bool canDeflect = false;

	// Use this for initialization
	void Start()
	{
	
	}

	void Update()
	{
		print("DEFLECT");
		//If the block button was pressed.
		if (ophionInput.blockButtonDown) {
			if(Time.time - lastDeflectTime < deflectTime)
			{
				canDeflect = true;

			}
			else{
				canDeflect = false;
			}

		}
	}

	void OnTriggerEnter(Collider other) 
	{
		//If the player is blocking
		if(ophionInput.blockButtonDown){
			//If the player can deflect
			if(canDeflect){
				if (other.gameObject.tag == "Bullet") {
					//Get the shooter position from the bullet and destroy it
					Transform bulletOrigin = other.GetComponentInChildren<BulletTest>().shooter;
					Destroy(other);

					//Generate a new bullet aimed at the shooter
					GameObject temp = (GameObject) Instantiate( Bullet, transform.position , Bullet.transform.rotation );
					temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
					lastDeflectTime = Time.time;
				}
			}
			//Make the bullet harmless
			else{
				Destroy(other);
			}
		}
	}
}
