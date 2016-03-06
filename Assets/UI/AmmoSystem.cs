using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoSystem : MonoBehaviour
{
	public Image indicator;
	public Text text;

	private float ammoLevel;

	void Update ()
	{
		indicator.fillAmount = ammoLevel;
		text.text = Mathf.RoundToInt (ammoLevel * 100f).ToString();
	}

	public void AmmoChange (float newLevel)
	{
		ammoLevel = newLevel;
	}
}
