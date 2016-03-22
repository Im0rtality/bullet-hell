using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuffableProperty: Observable
{
	public float baseValue;
	private List<IBuff2> effects = new List<IBuff2> ();

	public delegate float ValueModifier (float value);

	public ValueModifier valueModifier;


	public List<IBuff2> Effects {
		get { 
			return effects;
		}
	}

	public IBuff2 ApplyEffect (IBuff2 buff)
	{
		effects.Add (buff);

		return buff;
	}

	public void Update ()
	{
		effects.RemoveAll (effect => effect.Remaining < 0);

		foreach (IBuff2 effect in effects.FindAll(e => e.Target.Equals(BuffTarget.BaseValue))) {
			switch (effect.ModifierType) {
			case BuffModifier.Addition:
				baseValue += effect.Modifier ();
				break;
			case BuffModifier.Multiplication:
				baseValue *= effect.Modifier ();
				break;
			}
		}

		Notify (this);
	}

	public float Value {
		set {
			baseValue = value; 
		}
		get { 
			float value = baseValue;
			foreach (IBuff2 effect in effects.FindAll(e => e.Target.Equals(BuffTarget.Value))) {
				switch (effect.ModifierType) {
				case BuffModifier.Addition:
					value += effect.Modifier ();
					break;
				case BuffModifier.Multiplication:
					value *= effect.Modifier ();
					break;
				}
			}

			if (valueModifier != null) {
				value = valueModifier (value);
			}
			return value;
		}
	}
}
