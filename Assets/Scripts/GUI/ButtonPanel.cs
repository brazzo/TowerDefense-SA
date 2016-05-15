using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : Singleton<ButtonPanel>
{
	Button[] buttons;

	void Awake()
	{
		buttons = GetComponentsInChildren<Button>();
	}

	void OnEnable()
	{
		ClickHandler.Instance.OnObjectClick += ShowButtons;
		Level.OnDataChange += ShowButtons;
	}

	void Start()
	{
		DeactivateAllButtons();
	}

	void DeactivateAllButtons()
	{
		foreach (Button button in buttons)
		{
			button.gameObject.SetActive(false);
		}
	}

	void ShowButtons()
	{
		GameObject clickedObject = ClickHandler.Instance.GetClickedObject();

		if (clickedObject != null)
		{
			if (clickedObject.GetComponent<Tower>())
			{
				int level = clickedObject.GetComponent<Level>().GetLevel();
				switch (level)
				{

					case 0:
						buttons[0].gameObject.SetActive(true);
						buttons[0].GetComponentInChildren<Text>().text = "Erbauen";
						buttons[1].gameObject.SetActive(false);
						break;
					case 1:
						buttons[0].gameObject.SetActive(true);
						buttons[0].GetComponentInChildren<Text>().text = "Verstärken auf Level: " + level;
						buttons[1].gameObject.SetActive(true);
						buttons[1].GetComponentInChildren<Text>().text = "Zerstören";
						break;
					default:
						buttons[0].gameObject.SetActive(true);
						buttons[0].GetComponentInChildren<Text>().text = "Verstärken auf Level: " + level;
						buttons[1].gameObject.SetActive(true);
						buttons[1].GetComponentInChildren<Text>().text = "Herabstufen auf Level: " + (level - 1);
						break;
				}
			}
			else
			{
				DeactivateAllButtons();
			}
		}

	}
}
