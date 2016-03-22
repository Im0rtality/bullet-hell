using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DynamicDifficultyManager : MonoBehaviour
{
	public PooledSpawner asteroids;

	private int asteroidsBaseDiff;
	private float diffLevel = 1;

	void Start ()
	{
		asteroidsBaseDiff = asteroids.poolSize;
		InvokeRepeating ("Adjust", 0, 5);
//		InvokeRepeating ("IncreaseDifficulty", 0, 2);
	}

	void Adjust ()
	{
		Debug.Log ("Dynamic Difficulty: " + diffLevel.ToString ("N3"));

		asteroids.poolSize = Mathf.RoundToInt (asteroidsBaseDiff * diffLevel);
	}

	void IncreaseDifficulty ()
	{
		diffLevel *= 1.05f;
	}
}
