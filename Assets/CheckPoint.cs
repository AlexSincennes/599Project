using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		GameManager.Instance.player = player;
		if (GameManager.Instance.curTimes < 2) {
			//Debug.Log("lalala222");
			player.transform.position = new Vector3 (101f, 1.5f, 0.0f);//101
		} else {
			if(GameManager.Instance.spawnPointPos == Vector3.zero)
			{
				//Debug.Log("lalala1111");
				player.transform.position = new Vector3 (101f, 1.5f, 0.0f);
			} else
			{
				//Debug.Log("lalala");
				Camera.main.gameObject.transform.position = GameManager.Instance.spawnPointPos;
				player.transform.position = GameManager.Instance.spawnPointPos;

			}

		}
	}
	

}
