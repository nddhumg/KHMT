using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeStateManager : EnemyStateManager
{
    public IState moveState;

    public EnemyMeleeStateManager(Enemy enemy, SOStat stat) : base(enemy, stat)
    {

    }


    public override void Initialize()
    {
        base.Initialize();
        moveState = new MoveStateEnemy(this,stat.GetStatValue(EnumName.Stat.Speed));
        ChangeState(moveState);
    }

}
