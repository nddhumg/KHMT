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

        public DamageSkillComponent DamageComponent => damageComponent;
        public CoolDownSkillComponent CoolDownSkillComponent => coolDownComponent;

        protected virtual void Start()
        {
            damageComponent = new DamageSkillComponent(1, Player.instance.StatsManager.StatCurrent);
            coolDownComponent = new CoolDownSkillComponent(1);
            coolDownComponent.Timer.OnCoolDownEnd += Attack;
        }
        protected virtual void Update()
        {
            coolDownComponent.Update();
        }
        protected abstract void Attack();



        protected virtual Vector2 GetAttackDirection()
        {
            return Player.instance.Direction;
        }
    }
}
