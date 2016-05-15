using UnityEngine;

[System.Serializable]
class Weapon
{
	public float shootPower = 0, shootDelay = 0, zoneSize = 0;
}

[RequireComponent(typeof(ObjectPooler))]
class Gun : MonoBehaviour
{
	float shootPower;
	float shootDelay;
	float timeSinceLastShot;

	public void SetGun(float shootPower, float shootDelay)
	{
		this.shootPower = shootPower;
		this.shootDelay = shootDelay;
	}

	public void Shoot(GameObject target)
	{
		if (Time.time > shootDelay + timeSinceLastShot)
		{
			GameObject bullet = GetComponent<ObjectPooler>().GetPooledObject();
			if (bullet == null)
				return;
			bullet.transform.position = transform.position;
			bullet.SetActive(true);
			bullet.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized * Time.deltaTime * shootPower);
			timeSinceLastShot = Time.time;
		}
	}
}
