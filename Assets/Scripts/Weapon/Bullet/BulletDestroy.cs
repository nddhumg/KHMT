using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : DestroyAfterTime {

	protected override void DestroyObject ()
	{
		transform.parent.gameObject.SetActive (false);
	}
}
