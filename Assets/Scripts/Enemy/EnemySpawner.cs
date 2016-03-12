using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public float interval = 10;
	public int poolSize = 20;
	private List<GameObject> pool;
	public float area = 0;
	public GameObject enemyBase;

	void Start ()
	{
		InvokeRepeating ("Spawn", 0f, interval);
		pool = new List<GameObject> ();
		Random.seed = Random.Range (-999, 999);
	}

	void Spawn ()
	{
		pool.RemoveAll (obj => obj == null);
		if (pool.Count < poolSize) {
			Vector3 spawnPosition = area * Random.insideUnitSphere + transform.position;
			spawnPosition.z = Mathf.Clamp (spawnPosition.z, transform.position.z - 2f, transform.position.z + 2f);

			GameObject obj = Instantiate (enemyBase, spawnPosition, transform.rotation) as GameObject;
			pool.Add (obj);
		}
	}
}
