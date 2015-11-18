using UnityEngine;
using System.Collections;

public class AlertMark2D : MonoBehaviour {

	public GameObject alertSprite;

	void Start()
	{
		alertSprite.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			alertSprite.SetActive(true);
		}
	}


}
