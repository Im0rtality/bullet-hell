using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public int spawnerCount;

	void Awake() {
//		Application.targetFrameRate = 30;
	}

	void Start ()
	{
		Object spawnerPrefab = Resources.Load ("Spawner") as Object;
		for (int i = 0; i < spawnerCount; i++) {
			Instantiate (
				spawnerPrefab, 
				transform.position, 
				Quaternion.identity
			);
		}
	}
}
