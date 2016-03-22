using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitPointsManager : MonoBehaviour
{
	public Image indicator;
	public Text text;
	private float maxHp = 1;
	private float currentHp = 1;
	public Observer observerMaxHp;
	public Observer observerCurrentHp;

	void Start ()
	{
		observerMaxHp = new Observer (UpdateMaxHp);
		observerCurrentHp = new Observer (UpdateCurrentHp);
	}

	void Update ()
	{
		indicator.fillAmount = currentHp / maxHp;
		text.text = Mathf.RoundToInt (currentHp / maxHp * 100f).ToString ();
	}

	void UpdateMaxHp (BuffableProperty value)
	{
		maxHp = value.Value;
	}

	void UpdateCurrentHp (BuffableProperty value)
	{
		currentHp = value.Value;
	}
}
