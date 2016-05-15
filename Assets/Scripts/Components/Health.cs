using UnityEngine;

public interface IHealth
{
	bool AtZeroHealth();
}

class Health : MonoBehaviour, IHealth
{
	[SerializeField]
	int currentHealth;
	[SerializeField]
	int maxHealth = 100;

	void Awake() { SetMaxHealth(); }

	void SetZeroHealth() { currentHealth = 0; }

	void SetMaxHealth() { currentHealth = maxHealth; }

	bool AtMaxHealth() { return (currentHealth >= maxHealth); }

	public bool AtZeroHealth() { return (currentHealth <= 0); }

	public void ReduceHealth(int amount)
	{
		currentHealth -= amount;
		if (AtZeroHealth())
		{
			SetZeroHealth();
		}
	}

	public void IncreaseHealth(int amount)
	{
		currentHealth += amount;

		if (AtMaxHealth())
		{
			SetMaxHealth();
		}
	}
}
