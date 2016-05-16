using UnityEngine;
using System.Collections;

public class HideAfter : MonoBehaviour
{
	public float hideIn = 0.5f;

	void Update ()
	{
		Invoke ("Hide", hideIn);
	}

	void Hide ()
	{
		gameObject.SetActive (false);
	}
}
