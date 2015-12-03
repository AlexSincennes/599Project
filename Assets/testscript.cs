using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 7.0f * Time.deltaTime);
	}
}
