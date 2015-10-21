using UnityEngine;
using System.Collections;

public class BashManager : MonoBehaviour {

	private UILabel bashValueUI;
	private string bashValueString;
	public float curMeter;
	// Use this for initialization
	void Start () {
		bashValueUI = GameObject.Find ("ShieldBashMeter/Value").GetComponent<UILabel> ();
		curMeter = 0;
		bashValueUI.text = curMeter.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void UpdateBashMeter(float meter)
	{
		curMeter += meter;
		bashValueUI.text = curMeter.ToString();
	}

}
