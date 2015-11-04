using UnityEngine;
using System.Collections;

public class PlayerDestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			HitBox_2D collector = other.gameObject.GetComponent<HitBox_2D>();
			collector.Die();
		}
	}
}
