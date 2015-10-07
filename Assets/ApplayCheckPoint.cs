using UnityEngine;
using System.Collections;

public class ApplayCheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		//Debug.Log (other.gameObject.tag+"alalal");
		if (other.gameObject.tag == "Player") 
		{
			GameManager.Instance.spawnPointPos = transform.position;

			transform.GetChild(0).GetComponentInChildren<Renderer>().material.color = Color.red;
		}
	}
}
