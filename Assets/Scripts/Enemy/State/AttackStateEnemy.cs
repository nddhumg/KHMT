using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class AttackStateEnemy : EnemyState
    {
        protected EnemyArcStateManager rangedEnemyState;
        protected ICoolDownAuto timer;
        protected bool isAttack = true;
        protected GameObject bullet;
        public AttackStateEnemy(EnemyArcStateManager enemyState, float attackCoolDown, GameObject bullet) : base(enemyState)
        {
            timer = new AutoCooldownTimer(attackCoolDown);
            timer.AddTimeoutListener(Attack);
            this.bullet = bullet;
            rangedEnemyState = enemyState;
        }

        public override void Enter()
        {
            base.Enter();
            timer.ResetCooldown();
            isAttack = true;
        }

        public override void CheckChangeState()
        {
            if (!rangedEnemyState.IsInAttackRange() && !isAttack)
            {
                enemyState.ChangeState(rangedEnemyState.moveState);
                return;
            }
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            timer.UpdateCooldown(Time.deltaTime);
        }

        protected virtual void Attack()
        {
            MoveInDirection moveBullet = BulletManager.instance.Pool.Take(bullet, enemyState.GetPosition(), Quaternion.identity).GetComponentInChildren<MoveInDirection>();
            moveBullet.Direction = enemyState.GetDirecTionToPlayer();
            isAttack = false;
        }
    }
}