using UnityEngine;
using System.Collections;

public class VictoryW : MonoBehaviour {
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
}
