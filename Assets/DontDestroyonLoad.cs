using UnityEngine;
using System.Collections;

public class DontDestroyonLoad : MonoBehaviour {
	private static bool inst = false;
	void Awake() {
		if (inst) {
			DestroyImmediate(gameObject);
			return;
		} else {
			inst = true;
			DontDestroyOnLoad(gameObject);
		}
	}

}
