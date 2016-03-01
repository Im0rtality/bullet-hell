using UnityEngine;
using System.Collections;

public class SingleDimensionStatic : MonoBehaviour
{
	public Range boundaryX;
	public Range boundaryY;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private Vector3 startPos;
	private Vector3 startRot;

	private float currentSpeed;
	private float targetManeuver;

	void Start ()
	{
		startPos = transform.position;
		startRot = transform.rotation.eulerAngles;
		currentSpeed = GetComponent<Rigidbody> ().velocity.z;
		StartCoroutine (Evade ());
	}

	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody> ().velocity.x, targetManeuver, smoothing * Time.deltaTime);
		GetComponent<Rigidbody> ().velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		GetComponent<Rigidbody> ().position = startPos + new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundaryX.min, boundaryX.max), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundaryY.min, boundaryY.max)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (startRot.x, startRot.y, GetComponent<Rigidbody> ().velocity.x * -tilt);
	}
}
