using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	public GameObject spawner;

	void Update ()
	{
		transform.Rotate (new Vector3 (15, 15, 15));
	}

	void FixedUpdate ()
	{
//		if (Vector3.Distance (spawner.transform.position, transform.position) > 10f) {
//			Destroy (this);
//		}
	}
}
