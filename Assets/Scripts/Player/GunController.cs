using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{

	private LineRenderer lr;

	void Start ()
	{
		lr = GetComponent<LineRenderer> ();
		lr.enabled = false;
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("Fire");
			StartCoroutine ("Fire");
		}
	}

	IEnumerator Fire ()
	{
		lr.enabled = true;

		while (Input.GetButton ("Fire1")) {
			Ray ray = new Ray (transform.position, transform.forward);

			lr.SetPosition (0, ray.origin);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				lr.SetPosition (1, hit.point);

				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition (transform.forward * 5, hit.point);
				}

			} else {
				lr.SetPosition (1, ray.GetPoint (100));
			}

			yield return null;
		}

		lr.enabled = false;

	}
}
