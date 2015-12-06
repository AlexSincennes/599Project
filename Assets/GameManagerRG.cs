using UnityEngine;
using System.Collections;

public class GameManagerRG : MonoBehaviour {

	private static GameManagerRG _instance = null;
	public static GameManagerRG Instance
	{
		get { return _instance; }
	}

    public bool CastEnabled = false;

	public Vector3 spawnPointPos = Vector3.zero;
	public GameObject player;
	public GameObject ghost;
	public GameObject UIcanvas;
	public GameObject MainCamera;
	public GameObject RemoteCamera;
	public bool haveShield = false;

	void Awake()
	{

		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		
		_instance = this;
		
		DontDestroyOnLoad(gameObject);
	}
}
