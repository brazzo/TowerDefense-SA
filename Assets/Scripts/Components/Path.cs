using UnityEngine;

public class Path : MonoBehaviour
{
	int counter = 0;
	[SerializeField]
	Transform[] waypoints;

	void Update()
	{
		if (transform.position == waypoints[counter].position)
		{
			if (counter < waypoints.Length - 1)
			{
				counter++;
			}
		}
	}

	public Vector3 GetPath()
	{
		return waypoints[counter].position;
	}
}
