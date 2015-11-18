using UnityEngine;
using System.Collections;

public class CanvasCam : MonoBehaviour {
    private static bool instance = false;
	// Use this for initialization
	void Awake () {
        if (instance)
        {
            Debug.LogWarning("Second Canvas");
            DestroyImmediate(this.gameObject);
            return;
        }
        else
        {
            instance = true;
            DontDestroyOnLoad(gameObject);
        }
	}
	
}
