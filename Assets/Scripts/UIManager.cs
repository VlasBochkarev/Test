using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI TextScore ;
	public TextMeshProUGUI TextBestScore ;
	public static int Score = 0;


	private int _bestScore;




	private void Update()
	{
		ShowScore();
		ShowBestScore();
	}

	private void ShowScore()
	{
	
		TextScore.text = "Score: " + Score;
	}

	private void ShowBestScore()
	{
		
		if(PlayerPrefs.GetInt("_bestScore") < Score)
		{
			_bestScore = Score;
			PlayerPrefs.SetInt("_bestScore", _bestScore);
		}
		TextBestScore.text = "Best Score: " + PlayerPrefs.GetInt("_bestScore");
	}
}
