using Ndd.Cooldown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Pool;
using Ndd.Stat;
namespace Core.Enemies
{
    public class AttackStateEnemyArc : EnemyState
    {
        protected IEnemyArcStateManager rangedEnemyState;
        protected ICoolDownAuto timer;
        protected IPoolObject<GameObject, GameObject> pool;
        protected int damage;
        protected bool isAttack = true;
        protected GameObject bullet;
        public AttackStateEnemyArc(StateManager stateManager, IEnemyArcStateManager enemyState, int damage, float attackCoolDown, GameObject bullet, IPoolObject<GameObject, GameObject> pool) : base(stateManager)
        {
            this.stateManager = stateManager;
            timer = new AutoCooldownTimer(attackCoolDown);
            timer.AddTimeoutListener(Attack);
            this.bullet = bullet;
            this.pool = pool;
            this.damage = damage;
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
                base.stateManager.ChangeState(rangedEnemyState.MoveState);
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
            Bullet bulletScript = pool.Take(bullet, rangedEnemyState.GetPosition(), Quaternion.identity).GetComponent<Bullet>();
            bulletScript.SetDirection(rangedEnemyState.GetDirecTionToPlayer());
            bulletScript.SetDamage(damage);
            //moveBullet.Direction = rangedEnemyState.GetDirecTionToPlayer();
            isAttack = false;
        }
    }
}