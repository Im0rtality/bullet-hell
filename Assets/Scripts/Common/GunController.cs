using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
	private Weapon ctrl;

	public Weapon getWeapon ()
	{
		if (ctrl == null) {
			ctrl = gameObject.GetComponent<Weapon> ();
		}
		return ctrl;
	}

	public void Fire ()
	{
		if (getWeapon ().CanFire ()) {
			getWeapon ().InstantiateBullets ();

			getWeapon ().AfterFire ();
		}
	}
}
