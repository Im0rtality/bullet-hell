using UnityEngine;
using System.Collections;

public class ShipDamage : MonoBehaviour
{
	public Gradient g;
	private float lastBump = 0;
	private Material originalMaterial;
	public AudioClip explosion2;

	void Start ()
	{
		lastBump = Time.realtimeSinceStartup;
		originalMaterial = transform.GetComponent<Renderer> ().material;
	}

	void Update ()
	{
		float d = Mathf.Clamp01 ((Time.realtimeSinceStartup - lastBump) / 3f);
		if (d < 0.99f) {
			transform.GetComponent<Renderer> ().material.color = g.Evaluate (d);
		} else {
			transform.GetComponent<Renderer> ().material = originalMaterial;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.tag) {
		case "Asteroid":
			lastBump = Time.realtimeSinceStartup;
				//		AudioSource.PlayClipAtPoint (explosion2, transform.position);
			Object.Destroy (other.gameObject);
			break;				
		}
	}
}
