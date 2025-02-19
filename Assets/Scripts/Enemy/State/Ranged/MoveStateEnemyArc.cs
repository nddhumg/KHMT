using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateEnemyArc : MoveStateEnemy
{
    protected EnemyArcStateManager state;
    public MoveStateEnemyArc(EnemyArcStateManager enemyState, float speed) : base(enemyState, speed)
    {
        state = enemyState;
    }

    public override void CheckChangeState()
    {
        base.CheckChangeState();
        if (state.IsInAttackRange())
        {
            enemyState.ChangeState(state.attackState);
            return;
        }
    }
}
