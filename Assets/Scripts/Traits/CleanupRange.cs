using UnityEngine;
using System.Collections;

public class CleanupRange : MonoBehaviour
{
	public float allowedRange;
	private Vector3 startPos;

	void Start ()
	{
		startPos = transform.position;
	}

	void Update ()
	{
		if (Vector3.Distance (startPos, transform.position) > allowedRange) {
			Destroy (gameObject);
			BroadcastMessage ("onCleanupRange");
		}
	}
}
