using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill
{
    public class CoolDownSkillComponent
    {
        protected CoolDownTimer timer;
        protected float attackSpeed;

        public CoolDownTimer Timer => timer;
        public CoolDownSkillComponent(float attackSpeed)
        {
            this.attackSpeed = attackSpeed;
            this.timer = new CoolDownTimer(attackSpeed);
        }

        public void Update()
        {
            timer.CountTime(Time.deltaTime);
        }

        public virtual void IncreaseAttackSpeed(float value)
        {
            attackSpeed -= value;
            timer.CoolDown = attackSpeed;
        }

        public virtual void SetAttackSpeed(float value)
        {
            attackSpeed = value;
            timer.CoolDown = attackSpeed;
        }
    }

}
