using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.tag);

		if (other.tag == "Player") {
			HitBox_2D collector = other.gameObject.GetComponent<HitBox_2D>();
			collector.Die();
		}
		else if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
