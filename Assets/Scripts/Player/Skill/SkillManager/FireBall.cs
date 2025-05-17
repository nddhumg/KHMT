using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class FireBall : ShotSkill
    {
        [SerializeField] protected float recoildAmount = 0.3f;

        protected override void Start()
        {
            base.Start();
            damageComponent.SetDamageMultiplier(2f);
            coolDownComponent.SetAttackSpeed(3);
            muzzle = transform;

        }

        private void Reset()
        {
            muzzle = transform;
        }

        protected override Vector2 GetAttackDirection()
        {
            return Random.insideUnitCircle;
        }
        protected override void Attack()
        {
            StartCoroutine(CreateFireBall());
        }
        protected IEnumerator CreateFireBall()
        {
            GameObject bulletCurrent;
            float recoil = 0;
            Vector2 directionBullet = GetAttackDirection();
            Quaternion rotationBullet = new Quaternion();
            for (int countAmmo = 0; countAmmo < bulletCount; countAmmo++)
            {
                Vector2 directionBulletCurrent = directionBullet;
                recoil = Random.Range(-recoildAmount, recoildAmount);
                if (Random.value > 0.5)
                    directionBulletCurrent.y += recoil;
                else
                    directionBulletCurrent.x += recoil;
                directionBulletCurrent.Normalize();
                Debug.Log(Vector2.Angle(Vector2.down, directionBulletCurrent));
                rotationBullet = Quaternion.Euler(0f, 0f, (directionBulletCurrent.x > 0 ? 1 : -1) * Vector2.Angle(Vector2.down, directionBulletCurrent));
                bulletCurrent = BulletPool.instance.Spawn(this.bullet, muzzle.position, rotationBullet);
                bulletCurrent.GetComponentInChildren<MoveInDirection>().Direction = directionBulletCurrent;
                bulletCurrent.GetComponentInChildren<DamageSender>().SetDamage(damageComponent.GetDamge());

                yield return new WaitForSeconds(Random.Range(0, 0.1f));
            }
            coolDownComponent.Timer.ResetCoolDown();
            yield return null;
        }


    }
}
