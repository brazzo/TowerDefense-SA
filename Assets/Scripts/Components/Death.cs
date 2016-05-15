using UnityEngine;

[RequireComponent(typeof(Health))]
public class Death : MonoBehaviour
{
	[SerializeField]
	bool instantiateNewObject = false;
	[SerializeField]
	Transform objectToInstantiate;
	[SerializeField]
	float delayDestroy;

	IHealth health;

	void Start()
	{
		health = GetComponent<IHealth>();
	}
	void Update()
	{
		if (health.AtZeroHealth())
		{
			if (instantiateNewObject)
			{
				Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
			}
			Invoke("DestroyObject", delayDestroy);
		}
	}
	void DestroyObject()
	{
		gameObject.SetActive(false);
	}
}
