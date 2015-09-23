using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	public GameObject passLabel;
	public GameObject []family;

	private Vector3 endPos;
	// Use this for initialization
	void Start () {
		passLabel.SetActive (false);
		family [0].SetActive (false);
		family [1].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (family [0].activeInHierarchy && family [1].activeInHierarchy) 
		{
			//Debug.Log(family [0].transform.position.x - endPos.x);
			if (Mathf.Abs(family [0].transform.position.x - endPos.x) <= 0.01f) 
			{
				passLabel.SetActive(true);
			}
			if(Mathf.Abs(Camera.main.gameObject.transform.position.x - family [0].transform.position.x) <=0.01f)
			{
				family [0].transform.position = Vector3.MoveTowards(family [0].transform.position, endPos, Time.deltaTime * 15);
				family [1].transform.position = Vector3.MoveTowards(family [1].transform.position, endPos- new Vector3(2,0,0), Time.deltaTime * 15);
			}

		
		}


	}

	void OnTriggerEnter(Collider other)
	{
		family [0].SetActive (true);
		family [1].SetActive (true);
		Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = family [0].transform;

		endPos = new Vector3 (GameObject.Find ("HeroCharacter").transform.position.x,family [0].transform.position.y,family [0].transform.position.z); 
	}
}
