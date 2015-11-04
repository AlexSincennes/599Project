using UnityEngine;
using System.Collections;

public class VictoryW : Platform2D {
	public GameObject passLabel;


	// Use this for initialization
	void Start () {
		passLabel.SetActive (false);

	}
	void Update() {
	}
	override public void Collect() {
		GameManager.Instance.loadlev = 2;
		Application.LoadLevel (2);
		passLabel.SetActive (true);
	}
}
