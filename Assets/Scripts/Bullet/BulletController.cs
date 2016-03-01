using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	void onCollision ()
	{
		Destroy (gameObject);
	}
}
