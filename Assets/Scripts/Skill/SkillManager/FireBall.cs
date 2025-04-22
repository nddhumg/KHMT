using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class FireBall : ShotSkill
    {
        [SerializeField] protected int perFire = 3;
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

        public void IncreasePrerFire(int value)
        {
            perFire += value;
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
            for (int countAmmo = 0; countAmmo < perFire; countAmmo++)
            {
                Vector2 directionBulletCurrent = directionBullet;
                recoil = Random.Range(-recoildAmount, recoildAmount);
                if (Random.value > 0.5)
                    directionBulletCurrent.y += recoil;
                else
                    directionBulletCurrent.x += recoil;
                rotationBullet = Quaternion.Euler(0f, 0f, directionBullet.x > 0 ? Vector2.Angle(Vector2.down, directionBullet) : -Vector2.Angle(Vector2.down, directionBullet));
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
