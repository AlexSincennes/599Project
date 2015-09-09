﻿using UnityEngine;
using System.Collections;

public class DetectEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (2);

	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "Player")
			transform.parent.gameObject.GetComponent<Enemy1_2> ().SetState (1);
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		if( collision.gameObject.tag == "Player")
			Destroy(transform.parent.gameObject);
	}
}