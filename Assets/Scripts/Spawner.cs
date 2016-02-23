using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
	public List<Rigidbody> templates = new List<Rigidbody> ();
	public float interval = 2;
	public float area = 15;

	void Start ()
	{
		InvokeRepeating ("LaunchProjectile", 0f, interval + Random.Range (-0.5f, 0.5f));
	}

	void LaunchProjectile ()
	{
		Rigidbody potatoe = Instantiate (
			                    (templates [Random.Range (0, templates.Count)]).GetComponent<Rigidbody> (), 
			                    area * Random.onUnitSphere + transform.position, 
			                    Quaternion.identity
		                    ) as Rigidbody;

		potatoe.AddTorque (Random.rotation.eulerAngles * Random.Range (-2f, 2f));
	}
}
