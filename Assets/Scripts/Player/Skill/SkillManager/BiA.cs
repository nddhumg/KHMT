using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill {
    public class BiA : ShotSkill
    {
        [SerializeField] private uint maxCollider = 3;
        [SerializeField] private GameObject effectCollider;
        public GameObject EffectCollider => effectCollider;
        protected override void Start()
        {
            base.Start();
            coolDownComponent.SetAttackSpeed(5f);
        }

        private void Reset()
        {
            
            muzzle = transform;
        }

        protected override void Attack()
        {
            for (uint bulletIndex = 0; bulletIndex < bulletCount; bulletIndex++) {
                GameObject bulletSpawn = poolBullet.Take(bullet, transform.position, Quaternion.identity);
                bulletSpawn.GetComponent<BulletBiA>().Init(maxCollider, this);
                bulletSpawn.GetComponentInChildren<MoveInDirection>().Direction = GetAttackDirection();
                bulletSpawn.GetComponentInChildren<DamageSender>().SetDamage(damageComponent.GetDamge());
            }
        }


        protected override Vector2 GetAttackDirection()
        {
            return Random.insideUnitCircle;
        }
    }
}
