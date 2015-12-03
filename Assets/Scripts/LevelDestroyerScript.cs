using UnityEngine;
using System.Collections;

public class LevelDestroyerScript : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.tag);

		if (other.tag == "Terrain")
		{
			GameObject curr = other.gameObject;
			while (curr.transform.parent != null && 
			       curr.transform.parent.name != "StartPlatform" &&
			       curr.transform.parent.name != "PrefabContainer")
			{
				curr = curr.gameObject.transform.parent.gameObject;
			} 
			curr.SetActive(false);
		} 
		else {
			if(other.tag == "Player"){
				HitBox_2D collector = other.gameObject.GetComponent<HitBox_2D> ();
				collector.Die ();
			}
		}
	}
}
