using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public float rotSpeed = 1f;
	public float rotXAngle = 0f;
	public float rotYAngle = 30f;
	public float rotZAngle = 0f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (rotXAngle * rotSpeed, rotYAngle * rotSpeed, rotZAngle * rotSpeed) * Time.deltaTime);
	}
}
