using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
    private GameObject CastUI;
	public void LoadScene(int level)
	{
       
		Application.LoadLevel (level);
		loadingImage.SetActive (true);
        CastUI = GameObject.FindGameObjectWithTag("CastUI");
        CastUI.GetComponent<Canvas>().enabled = false;
        CastUI = GameObject.FindGameObjectWithTag("RemoteUI");
        CastUI.GetComponent<PauseMenu>().enabled = true;
        CastUI.GetComponent<Canvas>().enabled = false;
        
		CastUI = GameObject.FindGameObjectWithTag("Camera");
		//if(level == 2)
		//GameManager.Instance.curTimes++;
		//GameManager.Instance.curLevel = level;
	}
	public void OnOptions(){
	}
}
