using UnityEngine;
using System.Collections;

public class PlayerController : GunController
{
	public float tilt;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0f);
			
		rb.AddForce (movement * GetComponent<Player> ().speed.Value);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1")) {
			Fire ();
		}
	}

	void OnKilled ()
	{
		GameController.gameOver = true;
	}
}
