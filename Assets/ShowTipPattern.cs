using UnityEngine;
using System.Collections;

public class ShowTipPattern : MonoBehaviour {
	TipPatternManager tpm;
	public int curCombo;
	// Use this for initialization
	void Start () {
		tpm = GameManagerRG.Instance.MainCamera.GetComponentInChildren<TipPatternManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//manager
			tpm.setTrue(curCombo);
		}
	}


}
