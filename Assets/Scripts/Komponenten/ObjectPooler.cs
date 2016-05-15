using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
	[SerializeField]
	GameObject pooledObject;
	[SerializeField]
	int pooledAmount;
	[SerializeField]
	bool willGrow = true;
	List<GameObject> pooledObjects;

	void Awake()
	{
		pooledObjects = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			obj.transform.parent = transform;
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		if (willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}
		return null;
	}
}
