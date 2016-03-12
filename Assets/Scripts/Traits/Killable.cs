using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour
{
	public void DoKill ()
	{
		BroadcastMessage ("OnKilled", null, SendMessageOptions.DontRequireReceiver);
		Destroy (gameObject);
	}
}
