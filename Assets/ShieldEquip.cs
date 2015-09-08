using UnityEngine;
using System.Collections;

public class ShieldEquip : RaycastCharacterInput {

	public bool shieldEquipped;
	//private Vector3 moveDirection = Vector3.zero;
	// Update is called once per frame
	void Update () {
		//CharacterController controller = GetComponent<CharacterController>();
		if (Input.GetKeyDown(KeyCode.P) ) {
			if(shieldEquipped)
			{
				shieldEquipped = false;
				transform.Rotate(Vector3.up,79.09546f);
				transform.Rotate(new Vector3(0,0,1),04.26172f);
				//transform.Rotate(-74.26172f,0f,29.09546f,Space.Self);
				transform.Translate(new Vector3(0.2610001f, 0.15f, 0.5789997f));
				//transform.Translate(0, 0, 0.0789997f);
				//transform.Translate(0.3610001f, 0, 0);
				//transform.Translate(0, 0.47099998092652f, 0);
				//moveDirection = transform.TransformDirection(moveDirection);
				//controller.Move(moveDirection);
				
			}
			else
			{
				shieldEquipped = true;
				transform.Translate(new Vector3(-0.2610001f, -0.15f, -0.5789997f));
				transform.Rotate(new Vector3(0,0,1),-04.26172f);
				transform.Rotate(Vector3.up,-79.09546f);
				/*moveDirection = new Vector3(-0.40F, -0.5F, -0.13F);
				moveDirection = transform.TransformDirection(moveDirection);
				controller.Move(moveDirection);
				transform.Rotate(Vector3.up,45F);*/
			}
			
		
		}
	}
}
