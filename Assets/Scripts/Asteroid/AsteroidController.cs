using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour
{
	private GameObject player;
	public Gradient g;
	public float dangerZone = 20f;

	void Start ()
	{
		player = GameObject.Find ("Player");
	}

	void Update ()
	{
		Color cl;
		float distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
		if (distance < dangerZone) {
			cl = g.Evaluate (distance / dangerZone);
		} else {
			cl = Color.white;
		}
		gameObject.GetComponent<Renderer> ().material.color = cl;

		if (transform.position.y < 0) {
			Object.Destroy (gameObject);
		}
	}

	void FixedUpdate ()
	{
		if (transform.position.y < 0f) {
			Destroy (this);
		}
	}
}
