using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcStateManager : EnemyStateManager
{
    protected EnemyArc enemyArc;
    public AttackStateEnemy attackState;
    public MoveStateEnemyArc moveState;
    public EnemyArcStateManager(EnemyArc enemy, SOStat stat) : base(enemy, stat)
    {
        this.enemyArc = enemy;
    }

    public override void Initialize()
    {
        base.Initialize();
        attackState = new AttackStateEnemy(this, stat.GetStatValue(EnumName.Stat.AttackRate), enemyArc.Bullet);
        moveState = new MoveStateEnemyArc(this, stat.GetStatValue(EnumName.Stat.Speed));
        ChangeState(moveState);
    }

    public bool IsInAttackRange()
    {
        return Vector2.Distance(GetPosition(), GetPositionPlayer()) <= stat.GetStatValue(EnumName.Stat.AttackRange);
    }
}
