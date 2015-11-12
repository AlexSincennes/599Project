using UnityEngine;
using System.Collections;

public class LevelDestroyerScript : MonoBehaviour {
	public Transform follow;
	void Update(){
		if (follow == null)
			follow = GameObject.FindGameObjectWithTag ("Camera").transform;
		transform.position = new Vector3 (follow.position.x - 40.0f, follow.position.y - 0.5f, 0.0f);
	}
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.tag);

		if (other.tag != "Player") {
			if (other.gameObject.transform.parent) {
				Destroy (other.gameObject.transform.parent.gameObject);
			} else {
				Destroy (other.gameObject);
			}
		} else {
			HitBox_2D collector = other.gameObject.GetComponent<HitBox_2D> ();
			collector.Die ();
		}
	}
}
