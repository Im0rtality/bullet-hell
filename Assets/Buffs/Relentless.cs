using UnityEngine;
using System.Collections;

public class Relentless : IBuff2
{
	public float amount = 0;
	public float duration = 15f;
	private float startedAt = Time.fixedTime;

	public string GlyphName {
		get { return "Buffs/Relentless_Leader_Icon"; }
	}

	public BuffModifier ModifierType {
		get { return BuffModifier.Addition; }
	}

	public BuffDuration DurationType {
		get { return BuffDuration.Limited; }
	}

	public BuffTarget Target {
		get { return BuffTarget.Value; }
	}

	public float Remaining {
		get { return startedAt + duration - Time.fixedTime; }
	}

	public float Modifier ()
	{
		return amount;
	}
}
