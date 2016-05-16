using UnityEngine;
using System.Collections;

public class NonStopFire : GunController
{
	public float fireRate;
	public float delay;

	void Start ()
	{
		InvokeRepeating ("ScheduleFire", delay, fireRate);
	}

	void ScheduleFire()
	{
		Invoke ("Fire", fireRate * Random.Range(0.5f, 1.5f));
	}
}
