using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PooledSpawner : MonoBehaviour
{
	public float interval = 10;
	public int poolSize = 20;
	public float area = 0;
	public GameObject objBase;
	public bool initialSpawn;
	public bool respawn = true;
	public DynamicDifficultyManager levelUpMgr;

	private List<GameObject> pool = new List<GameObject> ();

	void Start ()
	{
		Random.seed = Random.Range (-999, 999);
		if (initialSpawn) {
			for (int i = 0; i < poolSize; i++) {
				AddObjectToPool ();
			}
		}

		InvokeRepeating ("Spawn", 0f, interval);
	}

	void Spawn ()
	{
		int count = pool.RemoveAll (obj => obj == null);
		if (levelUpMgr) {
			for (int i = 0; i < count; i++) {
				levelUpMgr.PoolObjectDestroyed ();
			}
		}
		if (pool.Count < poolSize && respawn) {
			AddObjectToPool ();
		}
	}

	void AddObjectToPool ()
	{
		GameObject player = GameObject.Find ("Player");
		Vector3 spawnPosition = area * Random.insideUnitSphere + (player ? player.transform.position : new Vector3());
		spawnPosition.z = Mathf.Clamp (spawnPosition.z, transform.position.z - 2f, transform.position.z + 2f);
		GameObject obj = Instantiate (objBase, spawnPosition, transform.rotation) as GameObject;
		pool.Add (obj);
	}
}
