using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			print("Destroying duplicate player");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	private void OnLevelWasLoaded(int level)
	{
		Debug.Log("MusicPlayer: loaded level " + level);
		music.Stop();

		if(level == 0)
			music.clip = startClip;
		if (level == 1 || level == 2 || level == 3)
		{
			music.clip = gameClip;
		}

		if (level == 4)
		music.clip = endClip;
		
		music.loop = true;
		music.Play();

	}
	
}
