using UnityEngine;
using System.Collections;

public class ShieldControl2D : MonoBehaviour {
	//public bool canReflect = false;
	public GameObject reflectItem;
	//public Transform attacker;
	public bool shieldEquip = false;
	public GameObject shieldmesh;
	public GameObject directionShield;
	public float reflectTime = 0.5f;
	public float angle = 0;
	//public GameObject shieldmeshBack;
	
	//public bool startClock = false;

	private bool isStartDefending;
	private float lastTime;
	private float defendStartTime;
	private GameObject playerGO ;

	// Use this for initialization
	void Start () {
		shieldmesh.SetActive (false);
		//shieldmeshBack.SetActive(true);
		//lastTime = 0;
		
		//set directionshield to default status
		directionShield.transform.localPosition = new Vector3 (0,0.2f,-1.5f);
		directionShield.transform.localEulerAngles = new Vector3 (0,0,0);
		directionShield.SetActive (false);
		playerGO = GameObject.Find("HeroCharacter2D");//GameManager.Instance.player;

		isStartDefending = false;
		lastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3(playerGO.transform.position.x,playerGO.transform.position.y,-10);
		if (angle != 0) 
		{
			if(!isStartDefending)
			{
				defendStartTime = Time.time;
				isStartDefending = true;
			}
			if(Time.time - defendStartTime >= reflectTime)
			{
				angle = 0;
				isStartDefending = false;
			}
		}

		if(shieldEquip ){
			playerGO.GetComponent<RaycastCharacterController2D>().movement.walkSpeed = 10;
			playerGO.GetComponent<RaycastCharacterController2D>().movement.runSpeed = 10f;
		}
		
		
		// directionshield control
		if(shieldEquip)
		{

			if(angle== 0)
			{
				shieldmesh.SetActive(true);
				directionShield.SetActive (false);
					//transform.parent.gameObject.GetComponentInChildren<Renderer>().material.color = new Color(0f,102f/255f,1f);
			}else
			{
				shieldmesh.SetActive(false);

				directionShield.transform.localPosition = new Vector3 (Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad)+0.2f,-1.5f);
				//Debug.Log(directionShield.transform.localPosition);
				directionShield.transform.localEulerAngles = new Vector3 (0,0,angle);
				directionShield.SetActive (true);												
						
			}
		}
}
}
