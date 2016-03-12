using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour
{
	public Image indicator;
	public Text text;

	private float level;

	void Update ()
	{
		indicator.fillAmount = level;
		text.text = Mathf.RoundToInt (level * 100f).ToString();
	}

	public void AmmoChange (float newLevel)
	{
		level = newLevel;
	}
}
