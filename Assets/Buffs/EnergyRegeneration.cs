using UnityEngine;
using System.Collections;

public class EnergyRegeneration : IBuff2
{
	public float amount = 0;
	public float interval = 3f;
	public float duration = 15f;
	private float startedAt = Time.fixedTime;
	private float nextApply;

	public string GlyphName {
		get { return "Buffs/_D3serenity"; }
	}

	public BuffModifier ModifierType {
		get { return BuffModifier.Addition; }
	}

	public BuffDuration DurationType {
		get { return BuffDuration.Unlimited; }
	}

	public BuffTarget Target {
		get { return BuffTarget.BaseValue; }
	}

	public float Remaining {
		get { return startedAt + duration - Time.fixedTime; }
	}

	public float Modifier ()
	{
		if (Time.time > nextApply) {
			nextApply = Time.fixedTime + interval;
			return amount;
		}
		return 0f;
	}
}
