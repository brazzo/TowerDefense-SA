using UnityEngine;

public class Enemy : MonoBehaviour
{
	Path path;
	Health health;

	[SerializeField]
	int speed;

	[SerializeField]
	int damagePerHit, scorePerHit;

	void Start()
	{
		path = GetComponent<Path>();
		health = GetComponent<Health>();
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, path.GetPath(), Time.deltaTime * Time.deltaTime * speed);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		health.ReduceHealth(damagePerHit);
		Score.Instance.Add(scorePerHit);
	}

}
