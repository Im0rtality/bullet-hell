using UnityEngine;
using System.Collections;

public class Weapon: MonoBehaviour
{
	protected Transform SpawnPoint;
	public GameObject Bullet;
	public AudioClip Sound;

	public virtual void Start ()
	{
		SpawnPoint = gameObject.transform.Find("GunTip") as Transform;
	}

	public virtual bool CanFire ()
	{
		return false;
	}

	public virtual void AfterFire ()
	{
	}

	public virtual void InstantiateBullets ()
	{
		SpawnBullet ();
	}

	protected void SpawnBullet ()
	{
		Instantiate (Bullet, SpawnPoint.position, SpawnPoint.rotation);
		if (Sound != null) {
			AudioSource.PlayClipAtPoint (Sound, SpawnPoint.position);
		}
	}
}
