using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public int spawnerCount;

	void Awake() {
		Application.targetFrameRate = 30;
	}

	void Start ()
	{
		Vector3 delta = new Vector3 (0f, 20f, 0f);
		Object spawnerPrefab = Resources.Load ("Spawner") as Object;
		for (int i = 0; i < spawnerCount; i++) {
			Instantiate (
				spawnerPrefab, 
				transform.position + delta + (Random.onUnitSphere * Random.Range (0, 15) / 3f), 
				Quaternion.identity
			);
		}
	}
}
