using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public Rigidbody bulletTemplate;

	// Update is called once per frame
	void Start ()
	{
		InvokeRepeating ("LaunchProjectile", 2, 0.3f);
	}

	void LaunchProjectile ()
	{
		float theta = Time.frameCount;

		Instantiate (
			bulletTemplate, 
			new Vector3 (
				Mathf.Sin (theta) * 0.5f,
				0f,
				Mathf.Cos (theta) * 0.5f
			) + transform.position, 
			Quaternion.identity
		);
	}
}
