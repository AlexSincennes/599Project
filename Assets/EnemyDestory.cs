using UnityEngine;
using System.Collections;

public class EnemyDestory : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Shield") 
		{
			//Destroy(transform.parent.gameObject);
			transform.parent.gameObject.GetComponent<Enemy1_2>().SetState(3);
			transform.parent.gameObject.SetActive(false);
			GameManagerRG.Instance.score += 10;
		}
		
		
	}
}
