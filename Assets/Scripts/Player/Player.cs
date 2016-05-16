using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public BuffableProperty maxHitpoints;
	public BuffableProperty hitPoints;
	public BuffableProperty speed;

	public List<string> damagingTags;
	public List<string> pickupTags;
	public HitPointsManager hp;
	public GameObject explosion;
	public AudioClip sound;
	public Image damageIndicator;

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
		if (damagingTags.IndexOf (other.tag) >= 0) {
			addHitPoints (-other.gameObject.GetComponent<Damaging> ().damage);

			if (explosion) {
				Instantiate (explosion, transform.position + new Vector3 (0, 0, 1), transform.rotation);
			}

			if (sound) {
				AudioSource.PlayClipAtPoint (sound, transform.position);
			}

			if (hitPoints.Value <= 0) {
				BroadcastMessage ("DoKill", null, SendMessageOptions.DontRequireReceiver);
			}

			if (damageIndicator) {
				Color cl = damageIndicator.color;
				damageIndicator.color = new Color (cl.r, cl.g, cl.b, 1.0f);
			}
		} else if (pickupTags.IndexOf (other.tag) >= 0) {
//			other.GetComponent<PickUp> ().apply (this);
			Debug.Log ("PickUp: " + other.tag);
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

	public void ApplyEffect (IBuff2 effect)
	{
		
	}
}
