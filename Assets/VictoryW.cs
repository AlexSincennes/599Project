using UnityEngine;
using System.Collections;

public class VictoryW : MonoBehaviour {
	public GameObject passLabel;


	// Use this for initialization
	void Start () {
		passLabel.SetActive (false);

	}

	void OnTriggerEnter2D(Collider2D other) {
		GameManager.Instance.loadlev = 1;
		Application.LoadLevel (1);
		passLabel.SetActive (true);
	}
}
