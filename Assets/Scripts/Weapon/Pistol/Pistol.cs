using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    private void Reset()
    {
        damageMultiplier = 5f;
        attackSpeed = 1f;
    }

    protected override void Attack ()
	{
		GameObject bullet = BulletPool.instance.Spawn (this.bullet,muzzle.position,Quaternion.identity);
		bullet.GetComponentInChildren<MoveInDirection> ().Direction = GetAttackDirection();
        bullet.GetComponentInChildren<DamageSender>().SetDamage(GetDamge());
	}

}
