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
			destination = transform.position + Random.insideUnitSphere * range;
			hasDestination = true;
			StartCoroutine ("PerformManeuver");
		}
	}

	IEnumerator PerformManeuver ()
	{
		while (Vector3.Distance (destination, transform.position) > 0.5f) {
			transform.position = Vector3.MoveTowards (transform.position, destination, speed);
			yield return new WaitForFixedUpdate ();
		}
		hasDestination = false;
	}
}
