using UnityEngine;
using System.Collections;

public class Scorable : MonoBehaviour
{
	public float score = 0;

	public void OnKilled ()
	{
		ScoreManager.score += score;
	}
}
