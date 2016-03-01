using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
	public GameObject shot;
	public float fireRate;

	private float nextFire;

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, transform.position, transform.rotation);
			//		GetComponent<AudioSource>().Play ();
		}
	}
}
