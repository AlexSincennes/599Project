using UnityEngine;
using System.Collections;

public class DontDie : MonoBehaviour {
	private static bool created = false;
	// Use this for initialization
	void Awake() {
		//DontDestroyOnLoad(transform.gameObject);
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
		else
			Destroy(this.gameObject);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
