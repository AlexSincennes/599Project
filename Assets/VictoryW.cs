using UnityEngine;
using System.Collections;

public class VictoryW : Platform2D {
	public GameObject passLabel;


	// Use this for initialization
	void Start () {
		passLabel.SetActive (false);

	}
	
	//// Update is called once per frame
	void Update () {

		
		}




	void OnTriggerEnter(Collider other)
	{


		GameManager.Instance.player.GetComponent<RaycastCharacterController> ().controllerActive = false;

		passLabel.SetActive (true);

	}
	override public void DoAction(RaycastCollider2D collider, RaycastCharacterController2D character) {
		GameManager.Instance.loadlev = 2;
		Application.LoadLevel (2);
		passLabel.SetActive (true);
	}
}
