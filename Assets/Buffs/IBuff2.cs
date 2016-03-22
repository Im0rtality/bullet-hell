using System;

public interface IBuff2
{
	BuffModifier ModifierType {
		get;
	}

	BuffDuration DurationType {
		get;
	}

	BuffTarget Target {
		get;
	}

	string GlyphName {
		get;
	}

	float Remaining {
		get;
	}

	float Modifier ();
}