using UnityEngine;
using System.Collections;

public class TipPatternManager : MonoBehaviour {

	public int curCombo;
	public UI2DSprite TipSprite;
	public Sprite[] comboPattern;
	public float showingTime = 1.0f;

	private bool isShowing = false;

	private float startTime;
	// Use this for initialization
	void Start () {
		TipSprite.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(isShowing)
		{
			if(Time.time - startTime > showingTime)
			{
				setFlase();
				isShowing = false;
			}
		}
	}

	public void setTrue(int curCombo)
	{
		isShowing = true;
		startTime = Time.time;
		this.curCombo = curCombo;
		TipSprite.sprite2D = comboPattern [curCombo];
		TipSprite.gameObject.SetActive (true);
	}

	public void setFlase()
	{
		this.curCombo = -1;
		TipSprite.gameObject.SetActive (false);
	}
}
