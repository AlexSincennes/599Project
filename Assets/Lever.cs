using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	public GameObject obj;
	public GameObject obj1;
	public GameObject lever;
	private bool isFirst;
	// Use this for initialization
	void Start () {
		isFirst = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player" && isFirst) 
		{
			lever.transform.Rotate(new Vector3(0,0,1),90);
			obj.SetActive(false);
			obj1.SetActive(false);
			isFirst = false;
		}
	}
}
