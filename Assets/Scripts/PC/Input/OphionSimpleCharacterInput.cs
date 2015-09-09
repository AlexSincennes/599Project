using UnityEngine;
using System.Collections;

/// <summary>
/// A simple character input. Arrows to move, left SHIFT to run, SPACE to jump.
/// </summary>
public class OphionSimpleCharacterInput : OphionRaycastCharacterInput
{
	public GameObject shield;
	public GameObject avatar;

	private Material mat;
	private Color red = new Color(0.8f, 0.0f, 0.0f);
	private Color blue = new Color(0.54f,0.64f,0.86f);

	void Start()
	{
		mat = avatar.GetComponent<SkinnedMeshRenderer>().material;
		shieldEquipButtonDown = false;
		mat.color = blue;
		shield.transform.Rotate(Vector3.up,79.09546f);
		shield.transform.Rotate(new Vector3(0,0,1),04.26172f);
		shield.transform.Translate(new Vector3(0.2610001f, 0.15f, 0.5789997f));
	}

	void Update ()
	{
		//Equip Shield - Left Alt
		if (Input.GetKeyDown (KeyCode.LeftAlt) ) {
			shieldEquipButtonDown = !shieldEquipButtonDown;
			if(shieldEquipButtonDown){
				mat.color = red;
				shield.transform.Translate(new Vector3(-0.2610001f, -0.15f, -0.5789997f));
				shield.transform.Rotate(new Vector3(0,0,1),-04.26172f);
				shield.transform.Rotate(Vector3.up,-79.09546f);
			}
			else{
				mat.color = blue;
				shield.transform.Rotate(Vector3.up,79.09546f);
				shield.transform.Rotate(new Vector3(0,0,1),04.26172f);
				shield.transform.Translate(new Vector3(0.2610001f, 0.15f, 0.5789997f));
			}
		}

		if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A))
		{
			if(!shieldEquipButtonDown)
			{
				for(int i =0; i<10000000; i++);
				shield.transform.Translate(new Vector3(-0.27f, 0.1f, -0.2f));
			}
			if(shieldEquipButtonDown)
			{
				for(int i =0; i<10000000; i++);
				shield.transform.Translate(new Vector3(-0.43f, -0.1f, 0.2f));
			}
		}
		else if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A))
		{
			if(!shieldEquipButtonDown)
			{
				for(int i =0; i<10000000; i++);
				shield.transform.Translate(new Vector3(0.27f, -0.1f, 0.2f));
			}
			if(shieldEquipButtonDown)
			{
				for(int i =0; i<10000000; i++);
				shield.transform.Translate(new Vector3(0.43f, 0.1f, -0.2f));
			}
		}

		//Block - Secondary Mouse Button
		if (Input.GetKeyDown (KeyCode.Mouse1) && shieldEquipButtonDown) {
			blockButtonDown = true;
		} 
		if (Input.GetKeyUp (KeyCode.Mouse1)){
			blockButtonDown = false;
		}
	}
}
