using UnityEngine;

public class Level : MonoBehaviour
{
	public delegate void OnDataChangeHandler();
	public static event OnDataChangeHandler OnDataChange;
	int level, maxLevel;

	public void SetMaxLevel(int maxLevel)
	{
		this.maxLevel = maxLevel;
	}
	public void LevelUp()
	{
		if (level < maxLevel)
		{
			level++;
			if (OnDataChange != null)
			{
				OnDataChange();
			}
		}
	}
	public void LevelDown()
	{
		if (level > 0)
		{
			level--;
			if (OnDataChange != null)
			{
				OnDataChange();
			}
		}
	}
	public int GetLevel()
	{
		return level;
	}
}
