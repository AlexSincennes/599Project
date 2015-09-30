using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance = null;
	public static GameManager Instance
	{
		get { return _instance; }
	}

	public int curLevel;
	public int curTimes;
	public Vector3 deathPos;
	public GameObject player;

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
