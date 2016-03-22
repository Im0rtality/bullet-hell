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
		Random.seed = Random.Range(0, 999999);
		nextFire = Time.time + Cooldown + Random.Range (0f, Cooldown * 0.1f);
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