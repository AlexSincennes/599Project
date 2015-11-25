using UnityEngine;
using System.Collections;
using Google.Cast.RemoteDisplay;

public class CastCam : MonoBehaviour {
    private GameObject Caster;
    private static bool CastEnabled = false;
    private GameObject MainCam;
    private GameObject RemoteCam;
	// Use this for initialization
	void Start () {
        Caster = GameObject.Find("CastRemoteDisplayManager");
        GameManager.Instance.CastEnabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Caster == null)
        {
            Caster = GameObject.Find("CastRemoteDisplayManager");
        }
        if (Caster != null && Caster.GetComponent<CastRemoteDisplayManager>().IsCasting() && !GameManager.Instance.CastEnabled)
        {
            MainCam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCam.GetComponent<Camera>().cullingMask = 0;
            GameManager.Instance.CastEnabled = true;
        }
        else if (Caster != null && !Caster.GetComponent<CastRemoteDisplayManager>().IsCasting() && GameManager.Instance.CastEnabled)
        {
            MainCam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCam.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("TransparentFX") | 1 << LayerMask.NameToLayer("IgnoreRaycast") | 1 << LayerMask.NameToLayer("Water") | 1 << LayerMask.NameToLayer("passthrough") | 1 << LayerMask.NameToLayer("l12") | 1 << LayerMask.NameToLayer("Checkpoint") | 1 << LayerMask.NameToLayer("enemybody") | 1 << LayerMask.NameToLayer("door") | 1 << LayerMask.NameToLayer("shield") | 1 << LayerMask.NameToLayer("bullet") | 1 << LayerMask.NameToLayer("detectionarea");
            GameManager.Instance.CastEnabled = false;
        }
	}
}
