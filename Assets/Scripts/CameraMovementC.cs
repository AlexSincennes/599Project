using UnityEngine;
using System.Collections;

public class CameraMovementC : MonoBehaviour {
	public Transform target;
	public float distance ;
	public float dotRatio= 0.7f;
	public float dashRatio =0.3f ;
	public bool isleftArea;


	private float cameraScreenHeight;
	private float cameraScreenwidth;
	private bool isGetCameraScreen = true;
	private bool isVictory = false;

	private float leftDot;
	private float leftDash;
	private float rightDot;
	private float rightDash;

	private int curDirection;

	private Vector3 areaSwitchTarget;
	private bool isSwitchingArea = false;

	private Victory levelVictory;
	//private Transform mainCamera;
	// Use this for initialization
	void Start () {

		if (target == null) 
		{
			target = GameManager.Instance.player.transform;
		}
		GameManager.Instance.player.GetComponent<RaycastCharacterController> ().controllerActive = false;

		if(GameManager.Instance.curTimes>1 || !GameManager.Instance.isCutScene )//Time.time - lasttime > 30
		{
			Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = GameManager.Instance.player.transform;
			GameManager.Instance.player.GetComponent<RaycastCharacterController>().controllerActive = true;
		}

		transform.position = new Vector3 (target.position.x, target.position.y + 5, target.position.z - distance);
		//Debug.Log (Screen.width + "  " + Screen.height);
		isVictory = false;
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = Vector3.MoveTowards (transform.position,new Vector3 (target.position.x,target.position.y+5,target.position.z -distance),Time.deltaTime*60); 
		if (isVictory) 
		{
			DoVictory ();
		} else 
		{
			if (!isGetCameraScreen) 
			{
				GetDotDashArea ();
			}
			CheckDotDashArea ();
		}
	}

	void LateUpdate()
	{
		if ( isGetCameraScreen && GameManager.Instance.player.GetComponent<RaycastCharacterController> ().controllerActive == true ) 
		{
			GetCameraScreen();
			GetDotDashArea ();
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x+cameraScreenwidth*dashRatio,Camera.main.transform.position.y,Camera.main.transform.position.z);

			isleftArea = true;
			isGetCameraScreen = false;
		}

	}

	void GetCameraScreen()
	{
		float halfFOV = ( Camera.main.fieldOfView * 0.5f ) * Mathf.Deg2Rad;
		float aspect = Camera.main.aspect;

		cameraScreenHeight = distance * Mathf.Tan( halfFOV );
		cameraScreenwidth = cameraScreenHeight * aspect;


	}

	void GetDotDashArea()
	{
		Transform tx = Camera.main.transform;
		leftDot = tx.position.x - cameraScreenwidth*dotRatio;
		leftDash = tx.position.x - cameraScreenwidth*dashRatio;
		rightDot = tx.position.x + cameraScreenwidth*dotRatio;
		rightDash = tx.position.x + cameraScreenwidth*dashRatio;

		//for debugging
		Debug.DrawLine( new Vector3(leftDot,tx.position.y+ cameraScreenHeight,0), new Vector3(leftDot,tx.position.y- cameraScreenHeight,0), Color.yellow );
		Debug.DrawLine( new Vector3(leftDash,tx.position.y+ cameraScreenHeight,0), new Vector3(leftDash,tx.position.y- cameraScreenHeight,0), Color.yellow );
		Debug.DrawLine( new Vector3(rightDot,tx.position.y+ cameraScreenHeight,0), new Vector3(rightDot,tx.position.y- cameraScreenHeight,0), Color.red );
		Debug.DrawLine( new Vector3(rightDash,tx.position.y+ cameraScreenHeight,0), new Vector3(rightDash,tx.position.y- cameraScreenHeight,0), Color.red );
	}

	void CheckDotDashArea()
	{
		curDirection = GameManager.Instance.player.GetComponent<DirectionChecker> ().CurrentDirection;
		Vector3 playerPos = GameManager.Instance.player.transform.position;
		//1 for right -1 for left.// Debug.Log("lala");
		if (isleftArea) 
		{
			if (curDirection == 1) //right
			{
				if(playerPos.x >= leftDash)
				{
					transform.position = Vector3.MoveTowards (transform.position
					                                          ,new Vector3 ((playerPos.x-leftDash + transform.position.x),transform.position.y,transform.position.z)
					                                          ,Time.deltaTime*60);
				}
			} else if (curDirection == -1) //left
			{
				if(playerPos.x <= leftDot || isSwitchingArea)
				{
					if(!isSwitchingArea)
					{
						areaSwitchTarget = new Vector3 (( transform.position.x-2*cameraScreenwidth*dotRatio),transform.position.y,transform.position.z);
						isSwitchingArea = true;
					}

					transform.position = Vector3.MoveTowards (transform.position ,areaSwitchTarget ,Time.deltaTime*120);

					if(Mathf.Abs(transform.position.x - areaSwitchTarget.x )<=0.01f)
					{
						isleftArea = false;
						isSwitchingArea = false;
					}
					                                        
				}
			}
		} else //rightArea
		{
			if (curDirection == 1) //right
			{
				if(rightDot <= playerPos.x || isSwitchingArea)
				{
					if(!isSwitchingArea)
					{
						areaSwitchTarget = new Vector3 (( transform.position.x+2*cameraScreenwidth*dotRatio),transform.position.y,transform.position.z);
						isSwitchingArea = true;
					}

					transform.position = Vector3.MoveTowards (transform.position ,areaSwitchTarget ,Time.deltaTime*100);

					if(Mathf.Abs(transform.position.x - areaSwitchTarget.x )<=0.01f)
					{
						isleftArea = true;
						isSwitchingArea = false;
					}

				}


			} else if (curDirection == -1) //left
			{
				if(rightDash >= playerPos.x)
				{
					transform.position = Vector3.MoveTowards (transform.position
					                                          ,new Vector3 ( (transform.position.x - (rightDash-playerPos.x) ),transform.position.y,transform.position.z)
					                                          ,Time.deltaTime*60);
				}
			}
		}
	}

	void DoVictory()
	{
		//move camera to family0
		transform.position = Vector3.MoveTowards (transform.position,new Vector3 (target.position.x,target.position.y+5,target.position.z -distance),Time.deltaTime*80); 

	}

	public void FirstLevelVictory(Victory win)
	{
		isVictory = true;
		levelVictory = win;
		target = win.family [0].transform;

	}


}
