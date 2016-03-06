using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public int spawnerCount;
	public static bool gameOver;
	public GameObject gameOverContainer;

	void Awake ()
	{
//		Application.targetFrameRate = 30;
		QualitySettings.SetQualityLevel(5);
		DontDestroyOnLoad(GameObject.Find("Directional Light"));
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

		//InvokeRepeating ("CountAsteroids", 0, 5);
		ScoreManager.score = 0;
		gameOver = false;
	}

	void Update ()
	{
		if (gameOver) {
			gameOverContainer.SetActive (true);
			if (Input.GetButton ("Submit")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void CountAsteroids ()
	{
		Debug.Log ("Asteroid count: " + GameObject.FindGameObjectsWithTag ("Asteroid").Length);
	}
}
