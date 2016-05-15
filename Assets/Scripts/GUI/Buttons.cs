using UnityEngine;

public class Buttons : MonoBehaviour
{
	public delegate void ButtonHandler();
	public static event ButtonHandler LevelUp;
	public static event ButtonHandler LevelDown;

	public void Up()
	{
		if (LevelUp != null)
		{
			LevelUp();
		}
	}

	public void Down()
	{
		if (LevelDown != null)
		{
			LevelDown();
		}
	}

}
