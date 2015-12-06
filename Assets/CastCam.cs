﻿using UnityEngine;
using System.Collections;
using Google.Cast.RemoteDisplay;

public class CastCam : MonoBehaviour {
	
	public float UIfadeTime = 1.0f;

    private CastRemoteDisplayManager Caster;
    private static bool CastEnabled = false;
    private GameObject MainCam;
    private GameObject RemoteCam;
	private CanvasGroup JumpTutorialCG;
	private CanvasGroup BlockTutorialCG;
	private SpawnScript Spawner;
	// Use this for initialization
	void Start () {
        Caster = GameObject.Find("CastRemoteDisplayManager").GetComponent<CastRemoteDisplayManager>();
		Spawner = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<SpawnScript>();
		JumpTutorialCG = GameObject.Find("JumpTutorialUI").GetComponent<CanvasGroup>();
		BlockTutorialCG = GameObject.Find ("BlockTutorialUI").GetComponent<CanvasGroup>();
        GameManager.Instance.CastEnabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Caster == null)
        {
            Caster = GameObject.Find("CastRemoteDisplayManager").GetComponent<CastRemoteDisplayManager>();
        }
        if (Caster != null && Caster.IsCasting() && !GameManager.Instance.CastEnabled)
        {
            MainCam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCam.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("UIadd");
             
            GameManager.Instance.CastEnabled = true;
        }
        else if (Caster != null && !Caster.IsCasting() && GameManager.Instance.CastEnabled)
        {
            MainCam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCam.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("Default") 
				| 1 << LayerMask.NameToLayer("TransparentFX") 
					| 1 << LayerMask.NameToLayer("IgnoreRaycast") 
					| 1 << LayerMask.NameToLayer("Water") 
					| 1 << LayerMask.NameToLayer("passthrough") 
					| 1 << LayerMask.NameToLayer("l12") 
					| 1 << LayerMask.NameToLayer("Checkpoint") 
					| 1 << LayerMask.NameToLayer("enemybody") 
					| 1 << LayerMask.NameToLayer("door") 
					| 1 << LayerMask.NameToLayer("shield") 
					| 1 << LayerMask.NameToLayer("bullet") 
					| 1 << LayerMask.NameToLayer("detectionarea")
					| 1 << LayerMask.NameToLayer("Destroyers")
                    | 1 << LayerMask.NameToLayer("UI");
            RemoteCam = GameObject.Find("JumpTutorialUI");
            RemoteCam.GetComponent<CanvasGroup>().alpha = 0f;
            RemoteCam = GameObject.Find("BlockTutorialUI");
            RemoteCam.GetComponent<CanvasGroup>().alpha = 0f;
            GameManager.Instance.CastEnabled = false;
        }
		//Fade in the buttons after the spawner starts
		if (Caster != null && Caster.IsCasting () && Spawner.isStarted () && !JumpTutorialCG.alpha.Equals (1.0f) && !BlockTutorialCG.alpha.Equals (1.0f)) {

			if (JumpTutorialCG.transform.parent.gameObject.layer.Equals (LayerMask.NameToLayer("UI"))){
				JumpTutorialCG.transform.parent.gameObject.layer = LayerMask.NameToLayer("UIadd");
				BlockTutorialCG.transform.parent.gameObject.layer = LayerMask.NameToLayer("UIadd");
			}

			var temp = JumpTutorialCG.alpha;
			temp += Time.deltaTime / UIfadeTime;
			JumpTutorialCG.alpha = temp;
			BlockTutorialCG.alpha = temp;
		}
	}
}
