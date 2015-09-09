using UnityEngine;
using System.Collections;

public class ShieldTest : MonoBehaviour {
	public bool canReflect = false;
	public GameObject reflectItem;
	public Transform attacker;
	public bool shieldEquip = false;
	public GameObject shieldmesh;
	public bool startClock = false;

	private float lastTime;



	// Use this for initialization
	void Start () {
		shieldmesh.SetActive (false);
		lastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (canReflect && startClock) 
		{
			lastTime = Time.time;
			startClock = false;
		}

		if (Time.time - lastTime > 0.2f) 
		{
			canReflect = false;
		}


		if (Input.GetKeyDown(KeyCode.LeftAlt)) {
			shieldEquip = !shieldEquip;
			shieldmesh.SetActive(shieldEquip);
			if(shieldEquip){
				transform.parent.gameObject.GetComponent<RaycastCharacterController>().movement.walkSpeed = 1;
				transform.parent.gameObject.GetComponent<RaycastCharacterController>().movement.runSpeed = 2;
			}else
			{
				transform.parent.gameObject.GetComponent<RaycastCharacterController>().movement.walkSpeed = 3;
				transform.parent.gameObject.GetComponent<RaycastCharacterController>().movement.runSpeed = 5.5f;
			}

		}



		if (shieldEquip && canReflect && Input.GetKey(KeyCode.Mouse1)) 
		{
			//Debug.Log(attacker.gameObject.name+"------------alalal");

			GameObject temp = (GameObject) Instantiate( reflectItem, transform.position,reflectItem.transform.rotation );
			temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
			temp.transform.GetComponentInChildren<BulletTest>().enemy = attacker;
			canReflect = false;
		}
	}
}
