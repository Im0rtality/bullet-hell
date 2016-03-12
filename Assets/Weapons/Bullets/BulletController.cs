using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	void onTriggerEnter (Collider other)
	{
		Debug.Log ("triggerEnter");
		Destroy (gameObject, 0.1f);
	}
}
