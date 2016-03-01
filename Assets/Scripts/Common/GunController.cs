using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
	public GameObject bullet;
	public Transform bulletSpawnPoint;
	public AudioClip sound;

	public void Fire ()
	{
		Instantiate (bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		if (sound != null) {
			AudioSource.PlayClipAtPoint (sound, transform.position);
		}
	}
}
