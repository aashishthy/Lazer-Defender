﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static int Lives;
	public static int Score = 0 ;

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{
		Debug.Log("Quit Requested");
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		Score = ScoreKeeper.sum;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	
	

}
