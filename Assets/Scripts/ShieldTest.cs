using UnityEngine;
using System.Collections;

public class ShieldTest : MonoBehaviour {
	//public bool canReflect = false;
	public GameObject reflectItem;
	//public Transform attacker;
	public bool shieldEquip = false;
	public bool shieldDefence = false;
	public GameObject shieldmesh;

	public GameObject directionShield;
	//public GameObject shieldmeshBack;

	//public bool startClock = false;
	
	private float lastTime;


	GameObject playerGO ;
	// Use this for initialization
	void Start () {
		shieldmesh.SetActive (false);
		//shieldmeshBack.SetActive(true);
		lastTime = 0;

		//set directionshield to default status
		directionShield.transform.localPosition = new Vector3 (0,0.5f,-0.5f);
		directionShield.transform.localEulerAngles = new Vector3 (0,0,0);
		directionShield.SetActive (false);
		playerGO = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (canReflect && startClock) 
		{
			lastTime = Time.time;
			startClock = false;
		}
		
		if (Time.time - lastTime > 0.2f) 
		{
			canReflect = false;
		}*/


		/*if (Input.GetKeyDown(KeyCode.LeftAlt)) {

			shieldEquip = !shieldEquip;
			shieldmesh.SetActive(shieldEquip);
			//shieldmeshBack.SetActive(!shieldEquip)			
		}*/

		if(shieldEquip && !shieldDefence){
			playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 6;
			playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 5.5f;
		}else if(!shieldEquip && !shieldDefence)
		{
			playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 6;
			playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 11f;
		}
		/*
		if (shieldEquip && canReflect ) //&& Input.GetKey(KeyCode.Mouse1)
		{
			//Debug.Log(attacker.gameObject.name+"------------alalal");

			GameObject temp = (GameObject) Instantiate( reflectItem, directionShield.transform.position,reflectItem.transform.rotation );
			temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
			temp.transform.GetComponentInChildren<BulletTest>().enemy = attacker;
			canReflect = false;
		}*/

		// directionshield control
		if(shieldEquip)
		{
			if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0)
			{

				shieldmesh.SetActive(true);
				directionShield.SetActive (false);
				shieldDefence = false;
			}else
			{
				shieldDefence = true;
				playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 0;
				playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 0;

				if(Input.GetAxis("Horizontal")<0 && Input.GetAxis("Vertical")==0)
				{
					
					//Debug.Log(Input.GetAxis("Horizontal")+"lala");
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (-1,0.5f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,0);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Horizontal")>0 && Input.GetAxis("Vertical")==0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (1,0.5f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,0);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Vertical")>0 && Input.GetAxis("Horizontal")==0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (0,1.5f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,90);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Vertical")<0 && Input.GetAxis("Horizontal")==0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (0,-1f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,90);
					directionShield.SetActive (true);
				}
				
				if(Input.GetAxis("Horizontal")<0&&Input.GetAxis("Vertical")>0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (-1,1f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,-45);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Horizontal")<0&&Input.GetAxis("Vertical")<0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (-1,-0.5f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,45);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Horizontal")>0&&Input.GetAxis("Vertical")>0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (1,1f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,45);
					directionShield.SetActive (true);
				}
				if(Input.GetAxis("Horizontal")>0&&Input.GetAxis("Vertical")<0)
				{
					shieldmesh.SetActive(false);
					directionShield.transform.localPosition = new Vector3 (1,-0.5f,-0.5f);
					directionShield.transform.localEulerAngles = new Vector3 (0,0,-45);
					directionShield.SetActive (true);
				}
			}

		}
	}
}
