using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
}
