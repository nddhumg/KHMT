using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemyArcStateManager : EnemyStateManager
    {
        protected EnemyArc enemyArc;
        public IState attackState;
        public IState moveState;

        private GameObject bullet;
        public EnemyArcStateManager(Enemy enemy, GameObject bullet) : base(enemy)
        {
           this.bullet = bullet;
        }

        public override void Initialize()
        {
            base.Initialize();
            attackState = new AttackStateEnemy(this, enemy.Stat.GetStatValue(EnumName.Stat.AttackRate), bullet);
            moveState = new MoveStateEnemyArc(this, enemy.Stat.GetStatValue(EnumName.Stat.Speed));
            ChangeState(moveState);
        }

        public bool IsInAttackRange()
        {
            return Vector2.Distance(GetPosition(), GetPositionPlayer()) <= enemy.Stat.GetStatValue(EnumName.Stat.AttackRange);
        }
    }
}
