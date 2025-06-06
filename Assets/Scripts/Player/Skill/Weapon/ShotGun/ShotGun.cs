using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Pool;
namespace Core.Skill
{
    public class ShotGun : ShotSkill
    {
        [SerializeField] protected uint fireSpread = 45;

        protected override void Start()
        {
            base.Start();
            damageComponent.SetDamageMultiplier(1);
            coolDownComponent.SetAttackSpeed(1.5f);
        }

        private void Reset()
        {
            bulletCount = 4;
        }

        protected override void Attack()
        {
            Vector2 directionShoot = new Vector2();
            directionShoot = RotateVector2(GetAttackDirection(), -fireSpread / 2f);
            float angle = fireSpread / bulletCount;
            GameObject bullet;
            MoveInDirection moveBullet;
            DamageSender damageBullet;
            for (int bulletIndex = 0; bulletIndex < bulletCount; bulletIndex++)
            {
                bullet = poolBullet.Take(this.bullet, muzzle.position, Quaternion.identity);
                moveBullet = bullet.GetComponentInChildren<MoveInDirection>();
                damageBullet = bullet.GetComponentInChildren<DamageSender>();
                moveBullet.Direction = directionShoot;
                damageBullet.SetDamage((int)Player.instance.StatsManager.StatCurrent.GetStatValue(EnumName.Stat.Damage));
                directionShoot = RotateVector2(directionShoot, angle);
            }
        }

        protected Vector2 RotateVector2(Vector2 vector, float angle)
        {
            float angleRadians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleRadians) * vector.x - Mathf.Sin(angleRadians) * vector.y;
            float y = Mathf.Sin(angleRadians) * vector.x + Mathf.Cos(angleRadians) * vector.y;
            return new Vector2(x, y);
        }
    }
}