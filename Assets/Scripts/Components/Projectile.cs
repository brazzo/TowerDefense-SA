using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D coll)
	{
		gameObject.SetActive(false);
	}
}
