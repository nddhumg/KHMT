using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : DestroyAfterTime {

    private void OnDisable()
    {
        timer.ResetCooldown();
    }

    protected override void DestroyObject ()
	{
		transform.parent.gameObject.SetActive (false);
	}
}
