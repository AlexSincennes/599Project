using UnityEngine;
using System.Collections;

public class AudioSync : MonoBehaviour {

	static int startedId = -1;
	public int id;

	AudioSource[] sources;
	
	public bool playOnStart;
	public enum PlayState { STOPPED, START, PLAYING, STOP };
	public PlayState playState;

	// Use this for initialization
	void Awake ()
	{
		if (startedId == id)
		{
			playState = PlayState.PLAYING;
		}
		else
		{
			if (playOnStart)
			{
				playState = PlayState.START;
			}
			else
			{
				playState = PlayState.STOPPED;
			}
			startedId = id;
		}
	}
	
	void Start ()
	{
		sources = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float time = Time.time;
		if (playState == PlayState.START)
		{
			for (int i = 0; i < sources.Length; i++)
			{
				sources[i].PlayScheduled(time + 30.0 * Time.deltaTime);
			}
			playState = PlayState.PLAYING;
		}
		else if (playState == PlayState.STOP)
		{
			for (int i = 0; i < sources.Length; i++)
			{
				sources[i].Stop();
			}
			playState = PlayState.STOPPED;
		}
	}
}
