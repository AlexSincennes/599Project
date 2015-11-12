using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject PauseUI;
	private GameObject CastUI;

	private bool paused = false;
	void Start () {
		if (CastUI == null)
			CastUI = GameObject.FindGameObjectWithTag ("CastUI");
	}

	// Update is called once per frame
	void Update () {
		if (CastUI == null)
			CastUI = GameObject.FindGameObjectWithTag ("CastUI");
		if (PauseUI == null)
			PauseUI = GameObject.FindGameObjectWithTag ("PauseUI");
		if(Input.GetButtonDown("Pause")){
			paused = !paused;
		}
		if (paused){
			PauseUI.SetActive(true);
			CastUI.GetComponent<Canvas>().enabled = true;
			//CastUI.SetActive(true);
			Time.timeScale = 0;
		}
		else if(!paused && PauseUI != null && CastUI != null){
			PauseUI.SetActive(false);
			CastUI.GetComponent<Canvas>().enabled = false;
			//CastUI.SetActive(false);
			Time.timeScale = 1.5f;
		}
	}

	public void Resume(){
		paused = false;
	}

	public void Restart(){
		/*GameObject obj = GameObject.FindGameObjectWithTag ("Spawner");
		obj.transform.parent = null;*/
		Application.LoadLevel (Application.loadedLevel);
		if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;
	}
	public void Exit(){
		GameObject obj = GameObject.FindGameObjectWithTag ("Spawner");
		obj.transform.parent = null;
		Application.LoadLevel(0);
	}
}
