using UnityEngine;
using System.Collections;

public class Repair : IBuff2
{
	public float amount = 0f;
	public float interval = 3f;
	private float nextApply;

	public string GlyphName {
		get { return "Buffs/Caduceus_Reactor_Icon"; }
	}

	public bool Finished {
		get { return false; }
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
		get { return float.MaxValue; }
	}

	public float Modifier ()
	{
		if (Time.fixedTime > nextApply) {
			nextApply = Time.time + interval;
			return amount;
		}
		return 0f;
	}
}
