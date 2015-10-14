using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public GameObject player;
	//// Use this for initialization
	void Start () 
	{
		GameManager.Instance.player = player;
		if (GameManager.Instance.curTimes < 2) {
			////Debug.Log("lalala222");
			player.transform.position = new Vector3 (-10f, 0.5f, 0.0f);//101
		} else {
			if(GameManager.Instance.spawnPointPos == Vector3.zero)
			{
				Debug.Log("lalala1111");
				player.transform.position = new Vector3 (-10f, 0.5f, 0.0f);
			} else
			{
				Debug.Log("lalala");
				player.transform.position = GameManager.Instance.spawnPointPos;
				Camera.main.gameObject.transform.position = GameManager.Instance.spawnPointPos;


			}

		}
	}
	

}
