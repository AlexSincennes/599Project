using UnityEngine;
using System.Collections;

public class PlayerDeath : Platform2D {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{		

		print ("Working");
		if (other.gameObject.tag == "Player") 
		{
			Application.LoadLevel(Application.loadedLevel);
			//GameManager.Instance.deathPos = other.transform.parent.position;
			if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;
		}
			

	}
	override public void DoAction(RaycastCollider2D collider, RaycastCharacterController2D character) {
		Application.LoadLevel(Application.loadedLevel);
		//GameManager.Instance.deathPos = other.transform.parent.position;
		if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;
	}
}
