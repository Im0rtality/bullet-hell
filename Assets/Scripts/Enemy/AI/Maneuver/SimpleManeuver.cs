using UnityEngine;
using System.Collections;

public class SimpleManeuver : MonoBehaviour
{
	public float range;
	public float speed;
	private Vector3 destination;
	private bool hasDestination;

	void FixedUpdate ()
	{
		if (!hasDestination) {
			GameObject player = GameObject.Find ("Player");
			destination = Random.insideUnitSphere * range + (player ? player.transform.position : new Vector3 (0, 0, 0));

			destination.Set (destination.x, destination.y, Mathf.Clamp (destination.z, 5.0f, 15.0f));
			hasDestination = true;
			StartCoroutine ("PerformManeuver");
		}
	}

	IEnumerator PerformManeuver ()
	{
		while (Vector3.Distance (destination, transform.position) > 0.5f) {
			GameObject player = GameObject.Find ("Player");

			transform.position = Vector3.MoveTowards (transform.position, destination, speed * calculateD());

			yield return new WaitForFixedUpdate ();
		}
		hasDestination = false;
	}

	float calculateD() {
		float d = 1f;
		GameObject player = GameObject.Find ("Player");
		if (player) {
			d = Mathf.Clamp(Mathf.Log(Vector3.Distance (player.transform.position, transform.position)), 1, 5);
		}

		return d;

	}
}
