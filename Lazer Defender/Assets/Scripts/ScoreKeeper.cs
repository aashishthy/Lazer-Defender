using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	public static int sum = 0;
	Text text;

	private void Start()
	{
		text = GetComponent<Text>();
		sum = LevelManager.Score;
		text.text = sum.ToString();
	}

	public void Score(int points)
	{
		sum += points;
		text.text = "" + sum;
	}

	public static void Reset()
	{
		sum = 0;
	}
}
