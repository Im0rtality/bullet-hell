using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
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

//		if (Input.GetAxisRaw ("Horizontal").CompareTo (0) != 0) {
//			player.AddTorque (new Vector3 (0f, Input.GetAxis ("Horizontal") / 10f, 0f));
//			CancelInvoke ("RestoreYaw");
//			Invoke ("RestoreYaw", 0.5f);
//		}
	}

	void RestoreYaw ()
	{
		transform.rotation = Quaternion.Euler (new Vector3 (270f, 0f, 0f));
	}
}
