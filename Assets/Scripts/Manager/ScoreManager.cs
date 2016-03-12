using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static float score;
	public Text scoreText;

	public void Reset ()
	{
		score = 0;
	}

	void Update ()
	{
		scoreText.text = "Score: " + Mathf.RoundToInt (score).ToString ();
	}
}
