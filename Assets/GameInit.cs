using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {
	public GameObject player;
	public GameObject ghost;
	public GameObject UIcanvas;
	public GameObject MainCamera;
	public GameObject RemoteCamera;
	// Use this for initialization
	void Start () {
        //Application.targetFrameRate = 60;
		GameManagerRG.Instance.player = player;
		GameManagerRG.Instance.ghost = ghost;
		GameManagerRG.Instance.UIcanvas = UIcanvas;
		GameManagerRG.Instance.MainCamera = MainCamera;
		GameManagerRG.Instance.RemoteCamera = GameObject.FindGameObjectWithTag("Camera");
	}
	
}
