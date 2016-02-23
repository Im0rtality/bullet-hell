using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	public GameObject spawner;
	private GameObject player;
	public Gradient g;
	public float speed = 2.0f;
	public float dangerZone = 20f;

	void Start ()
	{
		player = GameObject.Find ("Player");
	}

	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);

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
//		if (Vector3.Distance (spawner.transform.position, transform.position) > 10f) {
//			Destroy (this);
//		}
	}
}
