using Ndd.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public abstract class ShotSkill : MonoBehaviour
    {
        protected DamageSkillComponent damageComponent;
        protected CoolDownSkillComponent coolDownComponent;

        [SerializeField] protected GameObject bullet;
        [SerializeField] protected Transform muzzle;
        [SerializeField] protected uint bulletCount = 1;

        protected IPoolObject<GameObject, GameObject> poolBullet;
        public DamageSkillComponent DamageComponent => damageComponent;
        public CoolDownSkillComponent CoolDownSkillComponent => coolDownComponent;

        protected virtual void Start()
        {
            damageComponent = new DamageSkillComponent(1, Player.instance.StatsManager.StatCurrent);
            coolDownComponent = new CoolDownSkillComponent(1);
            coolDownComponent.Timer.AddTimeoutListener(Attack);
            poolBullet = BulletManager.instance.Pool;
        }
        protected virtual void Update()
        {
            coolDownComponent.Update();
        }

        public void SetBulletCount(uint bulletCount) { 
            this.bulletCount = bulletCount;
        }

        public void IncreaseBulletCount(uint increaseBullet) {
            this.bulletCount += increaseBullet;
        }

        protected abstract void Attack();


        protected virtual Vector2 GetAttackDirection()
        {
            return Player.instance.Direction;
        }
    }
}
