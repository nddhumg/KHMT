using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {
	[SerializeField] protected GameObject ammo;

	protected override void Attack ()
	{
		GameObject bullet = BulletPool.instance.GetFromPool (ammo,transform.position,Quaternion.identity);
		bullet.GetComponentInChildren<MoveInDirection> ().Direction = attackDirection;
        bullet.GetComponentInChildren<DamageSender>().SetDamage((int)Player.instance.StatsManager.GetStatValue(EnumName.Stat.Damage));
	}
}
