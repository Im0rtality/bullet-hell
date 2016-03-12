using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	private GameObject player;
	public Gradient g;
	public float dangerZone = 20f;

	void Start ()
	{
		player = GameObject.Find ("Player");
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * 20;
	}

	void Update ()
	{
		if (player != null) {
			Color cl;
			float distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
			if (distance < dangerZone) {
				cl = g.Evaluate (distance / dangerZone);
			} else {
				cl = Color.white;
			}
			gameObject.GetComponent<Renderer> ().material.color = cl;
		}
	}

	void onCleanupRange ()
	{
		if (player != null) {
			ScoreManager.score += 1;
		}
	}

	void DoExplode ()
	{
		ScoreManager.score += 1000;
	}
}
