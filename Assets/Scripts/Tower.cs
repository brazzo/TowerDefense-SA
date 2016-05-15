using UnityEngine;

class Tower : MonoBehaviour
{
	Zone zone;
	Gun gun;
	Level level;

	[SerializeField]
	int maxLevel;

	[SerializeField]
	Weapon[] weapons;

	void OnEnable()
	{
		Buttons.LevelUp += LevelUp;
		Buttons.LevelDown += LevelDown;
	}

	void Awake()
	{
		zone = GetComponent<Zone>();
		gun = GetComponent<Gun>();
		level = GetComponent<Level>();

	}

	void Start()
	{
		level.SetMaxLevel(maxLevel);
	}

	void FixedUpdate()
	{
		if (zone.TargetInZone)
		{
			gun.Shoot(zone.GetClosestTarget());
		}
	}

	void LevelUp()
	{
		if (ClickHandler.Instance.GetClickedObject() == gameObject)
		{
			level.LevelUp();
			SetWeapon();
		}
	}

	void LevelDown()
	{
		if (ClickHandler.Instance.GetClickedObject() == gameObject)
		{
			level.LevelDown();
			SetWeapon();
		}
	}
	void SetWeapon()
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			if (level.GetLevel() == i)
			{
				zone.SetZone(weapons[i].zoneSize);
				gun.SetGun(weapons[i].shootPower, weapons[i].shootDelay);
			}
		}

	}
}
