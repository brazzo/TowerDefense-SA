using UnityEngine;
using System.Collections;

[System.Serializable]
class Wave
{
	public Transform startPoint = null;
	public int enemiesPerWave = 0;
	public float spawnDelay = 0;
	public int startAfterLastWave = 0;
}

[RequireComponent(typeof(ObjectPooler))]
public class EnemyCreator : Singleton<EnemyCreator>
{
	[SerializeField]
	Wave[] waves;

	void Start() { StartCoroutine(CreateEnemies()); }

	public IEnumerator CreateEnemies()
	{
		for (int j = 0; j < waves.Length; j++)
		{
			yield return new WaitForSeconds(waves[j].startAfterLastWave);

			for (int i = 0; i < waves[j].enemiesPerWave; i++)
			{
				if (GetComponent<ObjectPooler>().GetPooledObject() != null)
				{
					GameObject enemy = GetComponent<ObjectPooler>().GetPooledObject();
					enemy.transform.position = waves[j].startPoint.position;
					enemy.SetActive(true);
				}
				yield return new WaitForSeconds(waves[j].spawnDelay);
			}


		}





	}
}
