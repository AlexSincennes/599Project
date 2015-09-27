using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		Application.LoadLevel (level);
		loadingImage.SetActive (true);
		GameManager.Instance.curTimes++;
		GameManager.Instance.curLevel = level;
	}
}
