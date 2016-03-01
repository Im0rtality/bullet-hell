using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int score;
	public Text scoreText;

	public void Reset ()
	{
		score = 0;
	}

	void Update ()
	{
		scoreText.text = "Score: " + score;
	}
}
