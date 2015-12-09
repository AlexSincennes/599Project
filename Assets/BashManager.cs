using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BashManager : MonoBehaviour {

    private Text bashValueUI;
	private string bashValueString;
	public int curMeter;
	private GameObject Hero;
	private float tim = 0.0f;
	public float delay;
	public int score;
	// Use this for initialization
	void Start () {
		bashValueUI = GameObject.Find ("ScoreCalculator/Score").GetComponent<Text> ();
		curMeter = 0;
		tim = 0;
		bashValueUI.text = curMeter.ToString ();
		tim = Time.timeSinceLevelLoad + delay;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.timeSinceLevelLoad > tim) {

			GameManagerRG.Instance.score += score;
			//print (score);
			bashValueUI.text = GameManagerRG.Instance.score.ToString();//curmeter
			tim = Time.timeSinceLevelLoad + delay;
		}
	}

	public void UpdateBashMeter(float meter)
	{
		curMeter += (int)meter;
		bashValueUI.text = curMeter.ToString();
	}

}
