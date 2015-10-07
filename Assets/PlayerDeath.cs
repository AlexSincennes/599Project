using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{		
		if (other.gameObject.tag == "Player") 
		{
			Application.LoadLevel(Application.loadedLevel);
			//GameManager.Instance.deathPos = other.transform.parent.position;
			if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;
		}
			

	}
}
