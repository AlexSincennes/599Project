using UnityEngine;
using System.Collections;

public class ShieldTest : MonoBehaviour {
	//public bool canReflect = false;
	public GameObject reflectItem;
	//public Transform attacker;
	public bool shieldEquip = false;
	public bool shieldDefence = false;
	public bool canUseShield = true;
	public GameObject shieldmesh;

	public GameObject directionShield;

	public float shieldcoldtime = 5f;
	public float shielddefencetime = 2f;
	private float curcoldtime;
	private float curdefencetime ;
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
		playerGO = GameManager.Instance.player;

		curcoldtime = shieldcoldtime;
		curdefencetime = shielddefencetime;
	}
	
	// Update is called once per frame
	void Update () {

		if(shieldEquip && !shieldDefence){
			playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 6;
			playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 5.5f;
		}else if(!shieldEquip && !shieldDefence)
		{
			playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 6;
			playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 11f;
		}


		// directionshield control
		if(shieldEquip)
		{
			if(curcoldtime>0)
			{
				if(canUseShield)
				{
					if(curdefencetime >0)
					{
						if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0)
						{
							
							shieldmesh.SetActive(true);
							directionShield.SetActive (false);
							shieldDefence = false;
							GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = true;	
							curdefencetime = shielddefencetime;
							transform.parent.gameObject.GetComponentInChildren<Renderer>().material.color = new Color(0.78f,0.78f,0.78f);
						}else
						{
							shieldDefence = true;
							//playerGO.GetComponent<RaycastCharacterController>().movement.walkSpeed = 0;
							//playerGO.GetComponent<RaycastCharacterController>().movement.runSpeed = 0;
							GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = false;	
							
							//limit use of shield
							curdefencetime -= Time.deltaTime;
							//Debug.Log(Color.Lerp(new Color(0.78f,0.78f,0.78f), new Color(1,0,0), (shielddefencetime-curdefencetime)/shielddefencetime));
							transform.parent.gameObject.GetComponentInChildren<Renderer>().material.color = Color.Lerp(new Color(0.78f,0.78f,0.78f), new Color(1,0,0), (shielddefencetime-curdefencetime)/shielddefencetime);

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
						
					}else
					{
						shieldmesh.SetActive(true);
						directionShield.SetActive (false);
						shieldDefence = false;
						GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = true;
						
						canUseShield = false;
						curdefencetime = shielddefencetime;
					}
				}else if(!canUseShield)
				{
					curcoldtime -= Time.deltaTime;

				}
			}else
			{
				canUseShield = true;
				curcoldtime = shieldcoldtime;
			}



		}
	}
}
