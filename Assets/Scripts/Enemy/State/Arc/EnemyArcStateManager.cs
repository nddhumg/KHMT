using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;
namespace Core.Enemies
{
    public class EnemyArcStateManager : EnemyStateManager, IEnemyArcStateManager
    {
        protected EnemyArc enemyArc;
        protected IState attackState;
        protected IState moveState;

        private GameObject bullet;

        public IState AttackState => attackState;
        public IState MoveState => moveState;

        public EnemyArcStateManager(Enemy enemy, GameObject bullet) : base(enemy)
        {
            this.bullet = bullet;
        }

        public override void Initialize()
        {
            base.Initialize();
            attackState = new AttackStateEnemyArc(this, this,(int)enemy.StatCurrent.GetStatValue(StatName.Damage), enemy.StatCurrent.GetStatValue(StatName.AttackRate), bullet, BulletManager.instance.Pool);
            moveState = new MoveStateEnemyArc(this, this, enemy.StatCurrent.GetStatValue(StatName.Speed));
            ChangeState(moveState);
        }

        public bool IsInAttackRange()
        {
            return Vector2.Distance(GetPosition(), GetPositionPlayer()) <= enemy.StatCurrent.GetStatValue(StatName.AttackRange);
        }
    }
}
