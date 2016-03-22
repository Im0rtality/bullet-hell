using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public BuffableProperty maxHitpoints;
	public BuffableProperty hitPoints;
	public BuffableProperty speed;

	public List<string> triggeringTags;
	public HitPointsManager hp;
	public GameObject explosion;
	public AudioClip sound;

	void Start ()
	{
		StatusEffectManager sem = GetComponent<StatusEffectManager> ();

		hitPoints.valueModifier = (value => {
			return ClampHitPoints (value);
		});

		hitPoints.Register (hp.observerCurrentHp);
		hitPoints.Register (sem.buffObserver);
		maxHitpoints.Register (hp.observerMaxHp);
		maxHitpoints.Register (sem.buffObserver);
		speed.Register (sem.buffObserver);

		hitPoints.Value = maxHitpoints.Value;

		hitPoints.ApplyEffect (new Repair (){ amount = 1f, interval = 1f });
		speed.ApplyEffect (new Relentless (){ duration = 5f });

		maxHitpoints.Update ();
		hitPoints.Update ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (triggeringTags.IndexOf (other.tag) >= 0) {
			addHitPoints (-other.gameObject.GetComponent<Damaging> ().damage);

			if (explosion) {
				Instantiate (explosion, transform.position, transform.rotation);
			}

			if (sound) {
				AudioSource.PlayClipAtPoint (sound, transform.position);
			}

			if (hitPoints.Value <= 0) {
				BroadcastMessage ("DoKill", null, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void addHitPoints (float value)
	{
		hitPoints.Value = ClampHitPoints (hitPoints.Value + value);
	}

	public void FixedUpdate ()
	{
		hitPoints.Update ();
		maxHitpoints.Update ();
		speed.Update ();
	}

	public float ClampHitPoints (float value)
	{
		return Mathf.Clamp (value, 0, maxHitpoints.Value);
	}
}
