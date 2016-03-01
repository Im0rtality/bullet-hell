using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (
			                   Input.GetAxis ("Horizontal"),
			                   0f,
			                   -Input.GetAxis ("Vertical")
		                   );
			
		rb.AddForce (movement * speed);
		rb.rotation = Quaternion.Euler (0.0f, rb.velocity.x * -tilt, 0.0f);
	}

	void RestoreYaw ()
	{
		transform.rotation = Quaternion.Euler (new Vector3 (270f, 0f, 0f));
	}
}
