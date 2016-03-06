using UnityEngine;
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
		heat = Mathf.Clamp (heat - coolingRate, 0.0f, maxHeat);
		Debug.Log ("Heat: " + heat);
	}

	public override bool CanFire ()
	{
		return Time.time > nextFire && maxHeat - heat > bulletHeat;
	}

	public override void AfterFire ()
	{
		nextFire = Time.time + fireRate;
		heat = Mathf.Clamp(heat + bulletHeat, 0, maxHeat);
	}
}