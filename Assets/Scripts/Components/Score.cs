public class Score : Singleton<Score>
{
	int score;

	public delegate void OnScoreChangeHandler();
	public event OnScoreChangeHandler OnScoreChange;

	public void Add(int score)
	{
		this.score += score;
		//Event Trigger

		if (OnScoreChange != null)
		{
			OnScoreChange();
		}
	}

	public void Reduce(int score)
	{
		this.score -= score;
		//Event Trigger
		if (OnScoreChange != null)
		{
			OnScoreChange();
		}
	}

	public int GetScore()
	{
		return score;
	}
}
