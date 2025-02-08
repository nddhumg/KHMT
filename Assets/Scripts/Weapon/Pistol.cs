using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {
	[SerializeField] protected GameObject ammo;

	protected override void HandleObject ()
	{
		GameObject bullet = BulletPool.instance.GetFromPool (ammo,transform.position,Quaternion.identity);
		MoveInDirection moveBullet = bullet.GetComponentInChildren<MoveInDirection> ();
		moveBullet.Direction = attackDirection;
	}
}
