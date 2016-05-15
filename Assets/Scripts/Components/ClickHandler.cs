using UnityEngine;
using UnityEngine.EventSystems;
public class ClickHandler : Singleton<ClickHandler>
{
	GameObject clickedObject;

	public delegate void OnObjectClickHandler();
	public event OnObjectClickHandler OnObjectClick;

	void Update()
	{
		ClickDetection();
	}

	void ClickDetection()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
			{
				clickedObject = hit.collider.gameObject;
				Debug.Log(clickedObject.name + " Clicked");
				if (OnObjectClick != null)
				{
					OnObjectClick();
				}
			}

		}
	}

	public GameObject GetClickedObject()
	{
		return clickedObject;
	}
}
