using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		/*GameObject obj = GameObject.FindGameObjectWithTag ("Spawner");
		obj.transform.parent = null;*/
		Application.LoadLevel (level);
		loadingImage.SetActive (true);
		if(level == 2)
		GameManager.Instance.curTimes++;
		GameManager.Instance.curLevel = level;
	}
	public void OnOptions(){
	}
}
