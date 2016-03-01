using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Exploding : MonoBehaviour
{
	public List<string> triggeringTags;
	public GameObject explosion;
	public AudioClip sound;

	void OnTriggerEnter (Collider other)
	{
		if (triggeringTags.IndexOf (other.tag) >= 0) {
			BroadcastMessage ("onTrigger" + other.tag, null, SendMessageOptions.DontRequireReceiver);

			if (explosion != null) {
				Instantiate (explosion, transform.position, transform.rotation);
			}

			if (sound != null) {
				AudioSource.PlayClipAtPoint (sound, transform.position);
			}

			other.BroadcastMessage ("onCollision", null, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
}
