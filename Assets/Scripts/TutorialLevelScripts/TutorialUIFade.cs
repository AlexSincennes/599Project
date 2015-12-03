using UnityEngine;
using System.Collections;

public class TutorialUIFade : MonoBehaviour {

	public CanvasGroup CG;
	public float fadeTime = 1f;

	private bool fadingIn = false;
	private bool fadingOut = false;

	void Update(){
		//If it's in the process of fading in
		if (fadingIn) {
			var temp = CG.alpha;
			temp += Time.deltaTime/fadeTime;
			CG.alpha = temp;
			//Check if done fading
			if(temp > fadeTime){
				fadingIn = false;
			}
		}
		else if(fadingOut){
			var temp = CG.alpha;
			temp -= Time.deltaTime/fadeTime;
			CG.alpha = temp;
			//Check if done fading
			if(temp < 0){
				fadingOut = false;
				CG.transform.gameObject.layer = LayerMask.NameToLayer("UIadd");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			fadingIn = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			fadingOut = true;
		}
	}
}
