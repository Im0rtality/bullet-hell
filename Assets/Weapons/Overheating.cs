using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Overheating: Weapon
{
	public float fireRate = 0.5f;
	public float maxHeat = 100.0f;
	public float coolingInterval = 0.020f;
	public float coolingRate = 0.5f;
	public float bulletHeat = 33.3f;
	private float heat = 0.0f;

	private float nextFire;

	public override void Start ()
	{
		InvokeRepeating ("Cooling", coolingInterval, coolingInterval);
		base.Start ();
	}

	void Cooling ()
	{
		setHeat (Mathf.Clamp (heat - coolingRate, 0.0f, maxHeat));
	}

	public override bool CanFire ()
	{
		return Time.time > nextFire && maxHeat - heat > bulletHeat;
	}

	public override void AfterFire ()
	{
		nextFire = Time.time + fireRate;
		setHeat (Mathf.Clamp (heat + bulletHeat, 0, maxHeat));
	}

	void setHeat (float value)
	{
		heat = value;

		if (ammoSystem) {
			ammoSystem.AmmoChange (1 - heat / maxHeat);
		}
	}
}