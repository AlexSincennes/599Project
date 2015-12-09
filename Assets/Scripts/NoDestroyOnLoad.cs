using UnityEngine;
using System.Collections;

public class NoDestroyOnLoad : MonoBehaviour {

	static NoDestroyOnLoad instance;

	void Awake()
	{
		GameObject go;
		if (instance)
		{
			Destroy(transform.gameObject);
		}
		else
		{
			DontDestroyOnLoad(transform.gameObject);
			instance = this;
		}
	}
	
	void OnLevelWasLoaded()
	{
		if (Application.loadedLevelName == "main_menu")
		{
			Destroy(transform.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
