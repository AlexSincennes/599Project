using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		if (GameManager.Instance.curTimes < 2) {
			player.transform.position = new Vector3 (13.8f, -2.9f, 0.1f);
		} else {
			player.transform.position = GameManager.Instance.deathPos;
		}
	}
	

}
