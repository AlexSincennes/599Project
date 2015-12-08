using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlowOutline : MonoBehaviour {
	
	public float fadeTime = 1f;
	public float minAlpha = 0f;
	public float maxAlpha = 45f;
	
	private bool fadingIn = false;
	private bool fadingOut = false;
	private Outline outline;

	void Start(){
		outline = GetComponent<Outline> ();
		minAlpha = (minAlpha > maxAlpha) ? maxAlpha : (minAlpha < 0) ? 0 : (minAlpha > 255) ? 255 : minAlpha;
		maxAlpha = (maxAlpha < minAlpha) ? minAlpha : (maxAlpha < 0) ? 0 : (maxAlpha > 255) ? 255 : maxAlpha;
		outline.effectColor = new Color (outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, (minAlpha + 1)/255f);
		fadingIn = true;
	}

	// Update is called once per frame
	void Update () {
		//If it's in the process of fading in
		if (fadingIn) {
			float temp = outline.effectColor.a;
			temp += Time.deltaTime/fadeTime * (maxAlpha - minAlpha)/255f;
			outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, temp);
			//Check if done fading
			if(temp > maxAlpha/255f){
				fadingIn = false;
				fadingOut = true;
			}
		}
		else if(fadingOut){
			float temp = outline.effectColor.a;
			temp -= Time.deltaTime/fadeTime * (maxAlpha - minAlpha)/255f;
			outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, temp);
			//Check if done fading
			if(temp < minAlpha/255f){
				fadingOut = false;
				fadingIn = true;
			}
		}
	}
}
