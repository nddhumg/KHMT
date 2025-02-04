using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : ObjectHandler {
	protected bool isShooting = false;

	protected override void HandleObject ()
	{
		Shoot ();
	}

	protected abstract void Shoot ();
}
