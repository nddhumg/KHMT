using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;
namespace Core.Skill
{
    public class DamageSkillComponent
    {
        [SerializeField] protected float damageMultiplier = 1;
        protected IStat statPlayer;

        public float DamageMultiplier => damageMultiplier;

        public DamageSkillComponent(float damageMultiplier, IStat stat)
        {
            this.damageMultiplier = damageMultiplier;
            this.statPlayer = stat;
        }

        public virtual void IncreaseDamageMultiplier(float value)
        {
            damageMultiplier += value;
        }

        public virtual void SetDamageMultiplier(float value)
        {
            damageMultiplier = value;
        }

        public virtual int GetDamge()
        {
            return (int)(statPlayer.GetStatValue(StatName.Damage) * damageMultiplier);
        }

    }
}
