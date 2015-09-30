﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject PauseUI;

	private bool paused = false;
	void Start () {
		PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause")){
			paused = !paused;
		}
		if (paused){
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		if(!paused){
			PauseUI.SetActive(false);
			Time.timeScale = 1.5f;
		}
	}

	public void Resume(){
		paused = false;
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void Exit(){
		Application.Quit();
	}
}