﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			print("Destroying duplicate player");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}