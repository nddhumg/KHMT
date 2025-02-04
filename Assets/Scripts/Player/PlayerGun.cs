using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun {
	protected Vector2 shootDirection = Vector2.down;
	[SerializeField] protected GameObject prefabBullet;

	void Start () {
		isShooting = true;
	}
	protected override void Update ()
	{
		base.Update ();
		if (JoyStick.instance.Direction != Vector2.zero) {
			shootDirection = JoyStick.instance.Direction;
		}
	}

	protected override void Shoot ()
	{
		GameObject bullet = BulletPool.instance.GetFromPool (prefabBullet,transform.position,Quaternion.identity);
		MoveInDirection moveBullet = bullet.GetComponentInChildren<MoveInDirection> ();
		moveBullet.Direction = shootDirection;
		moveBullet.Speed = 10;
	}
}
