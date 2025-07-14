using Core.Spawn.Enemy;
using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;

namespace Core.Enemies
{
    public class EnemyMelee : Enemy
    {
        protected int damageCollsion = 1;
        protected ICooldownChecker timer;
        protected float attackCoolDown = 0.3f;


        protected override void Update()
        {
            base.Update();
            timer.UpdateCooldown(Time.deltaTime);
        }

        public override void Init()
        {
            base.Init();
            damageCollsion = (int)statBase.GetStatValue(StatName.Damage) * EnemyManager.instance.Stat.GetBonusDamage();
            attackCoolDown = statBase.GetStatValue(StatName.AttackRate);
            timer = new CooldownChecker(attackCoolDown);
        }

        protected override void CreateStateManager()
        {
            state = new EnemyMeleeStateManager(this);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Player") || !timer.IsTimeout)
                return;
            IReceiveDamage receiver = collision.gameObject.GetComponentInChildren<IReceiveDamage>();
            if (receiver != null)
            {
                receiver.TakeDamage(damageCollsion);
                timer.ResetCooldown();
            }

        }
    }
}

