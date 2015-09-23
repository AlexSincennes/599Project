using UnityEngine;
using System.Collections;



public class Door : MonoBehaviour {

    public GameObject obj;
    // Use this for initialization
    void Start ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        obj.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
