using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	public GameObject passLabel;
	public GameObject []family;
	public bool canFamilyMove = false;
	private Vector3 endPos;
	// Use this for initialization
	void Start () {
		passLabel.SetActive (false);
		family [0].SetActive (false);
		family [1].SetActive (false);
	}
	
	//// Update is called once per frame
	void Update () {
		if (family [0].activeInHierarchy && family [1].activeInHierarchy) 
		{
			//Debug.Log(family [0].transform.position.x - endPos.x);
			if (Mathf.Abs(family [0].transform.position.x - endPos.x) <= 0.01f) 
			{
				passLabel.SetActive(true);
				Time.timeScale = 0;
				canFamilyMove = false;
			}
			if(canFamilyMove)
			{
				if(Mathf.Abs(Camera.main.gameObject.transform.position.x - family [0].transform.position.x) <=0.01f )
				{
					family [0].transform.position = Vector3.MoveTowards(family [0].transform.position, endPos, Time.deltaTime * 30);
					family [1].transform.position = Vector3.MoveTowards(family [1].transform.position, endPos+ new Vector3(3,0,0), Time.deltaTime * 30);
					
				}

			}

		
		}


	}

	void OnTriggerEnter(Collider other)
	{
		family [0].SetActive (true);
		family [1].SetActive (true);
		Camera.main.gameObject.GetComponentInChildren<CameraMovementC> ().target = family [0].transform;
		canFamilyMove = true;
		endPos = new Vector3 (GameManager.Instance.player.transform.position.x,family [0].transform.position.y,family [0].transform.position.z); 
	}
}
