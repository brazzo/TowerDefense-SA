using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePanel : Singleton<ScorePanel>
{

	Text score;

	void Awake()
	{
		score = GetComponentInChildren<Text>();
	}

	void OnEnable()
	{
		Score.Instance.OnScoreChange += ShowScore;
	}

	void Start()
	{
		ShowScore();
	}

	void ShowScore()
	{
		score.text = "Score: " + Score.Instance.GetScore().ToString();
	}


}
