using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	void onTriggerPlayerBullet ()
	{
		ScoreManager.score += 10000;
	}
}
