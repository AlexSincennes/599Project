using UnityEngine;
using System.Collections;

public class MenuSFX : MonoBehaviour {

	public AudioClip clickSound;
	
	private AudioSource source;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource>();
	}
	
	public void OnClickButton()
	{
		if (source)
		{
			source.PlayOneShot(clickSound);
		}
	}
}
