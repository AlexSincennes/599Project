using UnityEngine;
using System.Collections;

public class ShieldObject : MonoBehaviour {
	public GameObject Player;
	public static Transform player = null;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) 
	{
		//if (other.gameObject.tag == "Player") {
			ShieldTest temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			temp.shieldEquip = true;
			Destroy(this.gameObject);
		//}
	}
}
