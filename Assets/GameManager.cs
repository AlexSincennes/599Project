using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance = null;
	public static GameManager Instance
	{
		get { return _instance; }
	}

    public bool CastEnabled = false;
	public int curLevel;
	public int loadlev;
	public int curTimes;
	public Vector3 spawnPointPos = Vector3.zero;
	public GameObject player;
	public bool isCutScene = true;
	public bool haveShield = false;

	void Awake()
	{
		loadlev = 1;
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		
		_instance = this;
		
		DontDestroyOnLoad(gameObject);
	}
}
