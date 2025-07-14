using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class MoveStateEnemyArc : MoveStateEnemy
    {
        protected IEnemyArcStateManager arcStateManager;
        public MoveStateEnemyArc(EnemyArcStateManager stateManager, IEnemyArcStateManager arcStateManager, float speed) : base(stateManager,arcStateManager, speed)
        {
            this.arcStateManager = arcStateManager;
            this.arcStateManager = stateManager;
        }

        public override void CheckChangeState()
        {
            base.CheckChangeState();
            if (arcStateManager.IsInAttackRange())
            {
                stateManager.ChangeState(arcStateManager.AttackState);
                return;
            }
        }
    }
}
