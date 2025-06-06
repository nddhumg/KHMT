using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill
{
    public class CoolDownSkillComponent
    {
        protected ICoolDownAuto timer;
        protected float attackSpeed;

        public ICoolDownAuto Timer => timer;
        public CoolDownSkillComponent(float attackSpeed)
        {
            this.attackSpeed = attackSpeed;
            this.timer = new AutoCooldownTimer(attackSpeed);
        }

        public void Update()
        {
            timer.UpdateCooldown(Time.deltaTime);
        }

        public virtual void IncreaseAttackSpeed(float value)
        {
            attackSpeed -= value;
            timer.Cooldown = attackSpeed;
        }

        public virtual void SetAttackSpeed(float value)
        {
            attackSpeed = value;
            timer.Cooldown = attackSpeed;
        }
    }

}
