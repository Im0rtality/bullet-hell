using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damageable : MonoBehaviour
{
	public List<string> triggeringTags;
	public float maxHitpoints = 100f;
	private float hitPoints;
	public HitPointsManager hp;
	public GameObject explosion;
	public AudioClip sound;

	public void Start ()
	{
		setHitPoints (maxHitpoints);
	}

	void OnTriggerEnter (Collider other)
	{
		if (triggeringTags.IndexOf (other.tag) >= 0) {
			setHitPoints (Mathf.Clamp (hitPoints - other.gameObject.GetComponent<Damaging> ().damage, 0, maxHitpoints));

			if (explosion) {
				Instantiate (explosion, transform.position, transform.rotation);
			}

			if (sound) {
				AudioSource.PlayClipAtPoint (sound, transform.position);
			}

			if (hitPoints <= 0) {
				BroadcastMessage ("DoKill", null, SendMessageOptions.DontRequireReceiver);
			}
		}
	}


	void setHitPoints (float value)
	{
		hitPoints = value;

		if (hp) {
			hp.LevelChange (hitPoints / maxHitpoints);
		}
	}
}
