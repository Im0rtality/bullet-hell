using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	private Rigidbody player;

	void Start ()
	{
		player = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (
			                   Input.GetAxis ("Horizontal"),
			                   0f,
			                   -Input.GetAxis ("Vertical")
		                   );
			
		player.AddForce (movement * speed);
	}
}
