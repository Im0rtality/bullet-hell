using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DynamicDifficultyManager : MonoBehaviour
{
	public PooledSpawner asteroids;
	public Text levelIndicator;
	public Text levelUpIndicator;
	public int levelUpKills = 10;

	private int level = 0;
	private int remainingToLevel = 0;

	void Start ()
	{
		LevelUp ();
	}

	void LevelUp ()
	{
		remainingToLevel = levelUpKills;
		asteroids.poolSize = Mathf.RoundToInt (asteroids.poolSize * (1 + (level - 1) * 0.15f));
		Debug.Log ("Pool size: " + asteroids.poolSize.ToString ());
		level = level + 1;
		levelIndicator.text = "Level: " + level.ToString ();
		levelUpIndicator.text = "Level " + level.ToString ();
		levelUpIndicator.gameObject.SetActive (true);
	}

	public void PoolObjectDestroyed ()
	{
		remainingToLevel -= 1;
		if (remainingToLevel == 0) {
			LevelUp ();
		}
	}
}
