﻿using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {
	public GameObject player;
	public GameObject ghost;
	public GameObject UIcanvas;
	public GameObject MainCamera;
	public GameObject RemoteCamera;
	public GameObject Spawner;
	// Use this for initialization
	void Start () {
		GameManagerRG.Instance.player = player;
		GameManagerRG.Instance.ghost = ghost;
		GameManagerRG.Instance.UIcanvas = UIcanvas;
		GameManagerRG.Instance.MainCamera = MainCamera;
		GameManagerRG.Instance.RemoteCamera = GameObject.FindGameObjectWithTag("Camera");
		GameManagerRG.Instance.Spawner = Spawner;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}