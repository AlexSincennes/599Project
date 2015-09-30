using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		GameManager.Instance.player = player;
		if (GameManager.Instance.curTimes < 2) {
			player.transform.position = new Vector3 (12.9f, -2.9f, 0.0f);
		} else {
			player.transform.position = GameManager.Instance.deathPos;
		}
	}
	

}
