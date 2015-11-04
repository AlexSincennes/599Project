using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeTest : MonoBehaviour {
	
	public GameObject trail;
	//public Text swipeText;
	public GameObject Hero;
	public ShieldControl2D sc; 

	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_SwipeStart += On_SwipeStart;
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_SwipeEnd += On_SwipeEnd;		

		EasyTouch.On_SimpleTap += On_SimpleTap;

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

		EasyTouch.On_SimpleTap -= On_SimpleTap;	


	}
	


	// At the swipe beginning 
	private void On_SwipeStart( Gesture gesture){
		//swipeText.text = "You start a swipe";
	}
	
	// During the swipe
	private void On_Swipe(Gesture gesture){
		
		// the world coordinate from touch for z=5
		Vector3 position = gesture.GetTouchToWorldPoint(5);
		trail.transform.position = position;
		
	}
	
	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){
		
		// Get the swipe angle
		float angles = gesture.GetSwipeOrDragAngle();
		//swipeText.text = "Last swipe : " + gesture.swipe.ToString() + " /  vector : " + gesture.swipeVector.normalized + " / angle : " + angles.ToString("f2");
		//Debug.Log ("s1");
		//Hero.transform.eulerAngles = new Vector3 (0,angles,0);
		if ((angles > 135.0f && angles < 180.0f) || (angles > -180.0f && angles < -135.0f)) 
		{
			Hero.GetComponentInChildren<ShieldControl2D>().isBashing = true;
		} else 
		{
			sc.angle = angles;
		}

	}

	private void On_SimpleTap( Gesture gesture)
	{
		//Debug.Log (Screen.width);
		//if(gesture.position.x < Screen.width * 0.3f)
			Hero.GetComponent<SimpleCharacterInput> ().jump = true;

	}




}
