using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeTest : MonoBehaviour {
	
	public GameObject trail;
	//public Text swipeText;
	public GameObject Hero;
	public ShieldControl2D sc; 
	private bool isdefend = false;
	private Vector3 swipStartPos;
	
	public AudioClip jumpSound;
	
	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_SwipeStart += On_SwipeStart;
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_SwipeEnd += On_SwipeEnd;		

		EasyTouch.On_TouchStart += On_SimpleTap;

	}
	
	void OnDisable(){
		UnsubscribeEvent();
		
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_SwipeStart -= On_SwipeStart;
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_SwipeEnd -= On_SwipeEnd;	

		EasyTouch.On_TouchStart -= On_SimpleTap;	


	}

	// At the swipe beginning 
	private void On_SwipeStart( Gesture gesture){
		//swipeText.text = "You start a swipe";
		swipStartPos = gesture.GetTouchToWorldPoint(5);
		isdefend = true;

	}
	
	// During the swipe
	private void On_Swipe(Gesture gesture){
		// the world coordinate from touch for z=5
		if (gesture.position.x > Screen.width * 0.3f) 
		{
			Vector3 position = gesture.GetTouchToWorldPoint(5);
			trail.transform.position = position;

			//Debug.Log (Vector3.Distance(pos,position) +"hahaha");
			float dis = Vector3.Distance (swipStartPos, position);
			if (dis > 1 && isdefend) 
			{
				sc.defendStartTime = Time.time;
				isdefend = false;
				float angles = gesture.GetSwipeOrDragAngle();
				Debug.Log("Swipe Angle: " + angles);
				if ((angles > 135.0f && angles < 180.0f) || (angles > -180.0f && angles < -135.0f)) 
				{
					Hero.GetComponentInChildren<ShieldControl2D>().isBashing = true;
				} else 
				{
					sc.angle = angles;
					sc.isStartShield = true;
				}
				
			}
		}


		
	}
	
	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){
		isdefend = true;
		// Get the swipe angle
		/*
		float angles = gesture.GetSwipeOrDragAngle();

		if ((angles > 135.0f && angles < 180.0f) || (angles > -180.0f && angles < -135.0f)) 
		{
			Hero.GetComponentInChildren<ShieldControl2D>().isBashing = true;
		} else 
		{
			sc.angle = angles;
		}
		*/
	
	}

	private void On_SimpleTap( Gesture gesture)
	{
		//Debug.Log (Screen.width);
		if(gesture.position.x < Screen.width * 0.3f)
		{
			Hero.GetComponent<SimpleCharacterInput> ().jump = true;
			GetComponent<AudioSource>().PlayOneShot(jumpSound);
		}

	}




}
