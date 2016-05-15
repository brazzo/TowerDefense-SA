using UnityEngine;
using System.Collections;

public class Deactivator : MonoBehaviour
{
	[SerializeField]
	bool onStart, onEnable, onDisable;

	void Start()
	{
		if (onStart)
		{
			gameObject.SetActive(false);
		}
	}

	void OnEnable()
	{
		if (onEnable)
		{
			gameObject.SetActive(false);
		}
	}
	void OnDisable()
	{
		if (onDisable)
		{
			gameObject.SetActive(false);
		}
	}

}
