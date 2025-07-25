using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class Pistol : ShotSkill
    {

        protected override void Start()
        {
            base.Start();
            damageComponent.SetDamageMultiplier(5f);
            coolDownComponent.SetAttackSpeed(1);
        }

        protected override void Attack()
        {
            MusicManager.instance.PlaySFX(MusicKey.PistolShot);
            GameObject bullet = poolBullet.Take(this.bullet, muzzle.position, Quaternion.identity);
            bullet.GetComponentInChildren<MoveInDirection>().Direction = GetAttackDirection();
            bullet.GetComponentInChildren<DamageSender>().SetDamage(damageComponent.GetDamge());
        }

    }
}
