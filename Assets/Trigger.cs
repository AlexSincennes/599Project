using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		/*if (other.gameObject.tag == "Shield") {
			ShieldTest temp = transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			temp.shieldEquip = true;
			//Destroy(other.gameObject);
		}*/
	}
}
