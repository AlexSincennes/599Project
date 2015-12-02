using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlowOutline : MonoBehaviour {
	
	public float fadeTime = 1f;
	public float maxAlpha = 45f;
	
	private bool fadingIn = false;
	private bool fadingOut = false;
	private Outline outline;

	void Start(){
		outline = GetComponent<Outline> ();
		fadingIn = true;
	}

	// Update is called once per frame
	void Update () {
		//If it's in the process of fading in
		if (fadingIn) {
			float temp = outline.effectColor.a;
			temp += Time.deltaTime/fadeTime * maxAlpha/255f;
			outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, temp);
			//Check if done fading
			if(temp > maxAlpha/255f){
				fadingIn = false;
				fadingOut = true;
			}
		}
		else if(fadingOut){
			float temp = outline.effectColor.a;
			temp -= Time.deltaTime/fadeTime * maxAlpha/255f;
			outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, temp);
			//Check if done fading
			if(temp < 0){
				fadingOut = false;
				fadingIn = true;
			}
		}
	}
}
