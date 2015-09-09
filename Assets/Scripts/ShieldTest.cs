using UnityEngine;
using System.Collections;

public class ShieldTest : MonoBehaviour {
	public bool canReflect = false;
	public GameObject reflectItem;
	public Transform attacker;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canReflect) 
		{
			//Debug.Log(attacker.gameObject.name+"------------alalal");

			GameObject temp = (GameObject) Instantiate( reflectItem, transform.position,reflectItem.transform.rotation );
			temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
			temp.transform.GetComponentInChildren<BulletTest>().enemy = attacker;
			canReflect = false;
		}
	}
}
