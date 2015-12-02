using UnityEngine;
using System.Collections;

public class ShowTipPattern : MonoBehaviour {
	TipPatternManager tpm;
	// Use this for initialization
	void Start () {
		tpm = GameObject.Find("UI Root").GetComponentInChildren<TipPatternManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//manager
			tpm.setTrue(1);
		}
	}


}
