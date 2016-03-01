using UnityEngine;
using System.Collections;

public class PlayerController : GunController
{
	public float speed;
	public float tilt;
	private Rigidbody rb;

	public float fireRate;
	private float nextFire;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0f, -Input.GetAxis ("Vertical"));
			
		rb.AddForce (movement * speed);
		rb.rotation = Quaternion.Euler (0.0f, rb.velocity.x * -tilt, 0.0f);
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Fire ();
		}
	}

	void RestoreYaw ()
	{
		transform.rotation = Quaternion.Euler (new Vector3 (270f, 0f, 0f));
	}
}
