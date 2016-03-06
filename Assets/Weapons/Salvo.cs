using UnityEngine;
using System.Collections;

public class Salvo: Weapon
{
	public float Cooldown = 1.0f;
	public int Size = 3;

	private float nextFire;

	public override bool CanFire ()
	{
		return Time.time > nextFire;
	}

	public override void AfterFire ()
	{
		nextFire = Time.time + Cooldown;
	}

	public override void InstantiateBullets ()
	{
		StartCoroutine ("CoInstantiateBullets");
	}

	public IEnumerator CoInstantiateBullets ()
	{
		for (int i = 0; i < Size; i++) {
			SpawnBullet ();
			yield return new WaitForSeconds (0.05f);
		}
	}
}