using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
class Zone : MonoBehaviour
{
	List<GameObject> targets;
	bool targetInZone;
	CircleCollider2D circle;
	Rigidbody2D rigid;

	public bool TargetInZone
	{
		get { return targetInZone; }
	}

	void Awake()
	{
		targets = new List<GameObject>();
		circle = GetComponent<CircleCollider2D>();
		rigid = GetComponent<Rigidbody2D>();
		rigid.gravityScale = 0;
	}

	public void SetZone(float radius)
	{
		circle.isTrigger = true;
		circle.radius = radius;
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if (!targets.Contains(coll.gameObject))
		{
			targets.Add(coll.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (targets.Contains(coll.gameObject))
		{
			targets.Remove(coll.gameObject);
		}
	}

	void Update()
	{
		if (targets.Count > 0)
		{
			targetInZone = true;

			List<GameObject> targetsToRemove = new List<GameObject>();

			foreach (GameObject target in targets)
			{
				if (!target.activeSelf)
				{
					targetsToRemove.Add(target);
				}
			}

			if (targetsToRemove.Count > 0)
			{
				foreach (GameObject target in targetsToRemove)
				{
					targets.Remove(target);
				}
			}
		}
		else targetInZone = false;
	}

	public GameObject GetClosestTarget()
	{
		if (targets.Count > 0)
		{
			float distance = Mathf.Infinity;
			GameObject closestTarget = null;

			foreach (GameObject target in targets)
			{
				float currentDistance = (transform.position - target.transform.position).sqrMagnitude;

				if (currentDistance < distance)
				{
					distance = currentDistance;
					closestTarget = target;
				}
			}
			return closestTarget;
		}
		return null;
	}
}
