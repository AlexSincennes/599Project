using UnityEngine;
using System.Collections;

public class HeroAudioController : MonoBehaviour {

	public AudioClip[] sounds;
	private AudioSource source;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PlaySound(string soundName)
	{
		foreach (AudioClip sound in sounds)
		{
			if (sound.name.Equals(soundName))
			{
				source.PlayOneShot(sound);
				return;
			}
		}
	}
}
