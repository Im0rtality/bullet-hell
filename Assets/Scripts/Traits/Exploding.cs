using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Exploding : MonoBehaviour
{
	public GameObject explosion;
	public AudioClip sound;

	void OnKilled ()
	{
		if (explosion != null) {
			GameObject explObj = (GameObject) Instantiate (explosion, transform.position, transform.rotation);
			Destroy (explObj, 5f);
		}

		if (sound != null) {
			AudioSource.PlayClipAtPoint (sound, transform.position);
		}
	}
}
