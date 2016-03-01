using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
	public int worth;

	public void Award ()
	{
		ScoreManager.score += worth;
	}
}
