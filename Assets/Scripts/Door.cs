using UnityEngine;
using System.Collections;



public class Door : MonoBehaviour {

    public GameObject obj;
	public GameObject obj1;
    // Use this for initialization
    void Start ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        obj.SetActive(false);
		obj1.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
