using UnityEngine;
using System.Collections;

public class ShieldTest : MonoBehaviour {
	public bool canReflect = false;
	public GameObject reflectItem;
	public Transform attacker;
	public bool shieldEquip = false;
	public GameObject shieldmesh;

	// Use this for initialization
	void Start () {
		shieldmesh.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftAlt)) {
			shieldEquip = !shieldEquip;
			shieldmesh.SetActive(shieldEquip);
		}
		if (shieldEquip && canReflect && Input.GetKey(KeyCode.Mouse1)) 
		{
			//Debug.Log(attacker.gameObject.name+"------------alalal");

			GameObject temp = (GameObject) Instantiate( reflectItem, transform.position,reflectItem.transform.rotation );
			temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
			temp.transform.GetComponentInChildren<BulletTest>().enemy = attacker;
			canReflect = false;
		}
	}
}
