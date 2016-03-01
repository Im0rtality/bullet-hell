using UnityEngine;
using System.Collections;

public class NonStopFire : GunController
{
	public float fireRate;
	public float delay;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}
}
