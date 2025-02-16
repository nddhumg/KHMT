using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon {
	[SerializeField] protected GameObject ammo;
	[SerializeField] protected uint shotPelletCount = 4;
	[SerializeField] protected uint fireSpread = 45;
	protected override void Attack (){
		Vector2 directionShoot = new Vector2 ();
		directionShoot = RotateVector2 (attackDirection, -fireSpread / 2f);
		float angle =fireSpread / shotPelletCount;
		GameObject bullet;
		MoveInDirection moveBullet;
		DamageSender damageBullet;
		for (int bulletCount = 0; bulletCount < shotPelletCount; bulletCount++) {
			bullet = BulletPool.instance.GetFromPool (ammo, transform.position, Quaternion.identity);
			moveBullet = bullet.GetComponentInChildren<MoveInDirection> ();
			damageBullet = bullet.GetComponentInChildren<DamageSender>();
            moveBullet.Direction = directionShoot;
			damageBullet.SetDamage((int)Player.instance.StatsManager.GetStatValue(EnumName.Stat.Damage));
            directionShoot = RotateVector2 (directionShoot,angle);
		}
	}

	protected Vector2 RotateVector2(Vector2 vector, float angle){
		float angleRadians = angle * Mathf.Deg2Rad;
		float x = Mathf.Cos(angleRadians) * vector.x - Mathf.Sin(angleRadians) * vector.y;
		float y = Mathf.Sin(angleRadians) * vector.x + Mathf.Cos(angleRadians) * vector.y;
		return new Vector2(x, y);
	}
}
