using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill {
    public class BiA : ShotSkill
    {
        [SerializeField] private uint maxCollider = 3;

        protected override void Start()
        {
            base.Start();

        }

        private void Reset()
        {
            muzzle = transform;
        }

        protected override void Attack()
        {
            GameObject bulletSpawn = BulletPool.instance.Spawn(bullet, transform.position, Quaternion.identity);
            bulletSpawn.GetComponent<BulletBiA>().MaxCollider = maxCollider;
            int  test= (int)bulletSpawn.GetComponent<BulletBiA>().MaxCollider;
            Debug.Log(test.ToString(), bulletSpawn);
            bulletSpawn.GetComponentInChildren<MoveInDirection>().Direction = GetAttackDirection();
            bulletSpawn.GetComponentInChildren<DamageSender>().SetDamage(damageComponent.GetDamge());

        }

        protected override Vector2 GetAttackDirection()
        {
            return Random.insideUnitCircle;
        }
    }
}
