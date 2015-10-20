using UnityEngine;
using System.Collections;

public class EnemyDestory : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Shield") 
		{
			Destroy(transform.parent.gameObject);
		}
		
		
	}
}
