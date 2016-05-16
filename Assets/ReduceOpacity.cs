using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReduceOpacity : MonoBehaviour
{
	void FixedUpdate ()
	{
		Color cl = GetComponent<Image> ().color;
		GetComponent<Image> ().color = new Color (cl.r, cl.g, cl.b, Mathf.Clamp01(cl.a - 0.015f));
	}
}
