using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;

namespace Core.Enemies
{
    public class EnemyMeleeStateManager : EnemyStateManager, IEnemyMeleeStateManager
    {
        IState moveState;
        public IState MoveState => moveState;

        public EnemyMeleeStateManager(Enemy enemy) : base(enemy)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            moveState = new MoveStateEnemy(this, this, enemy.StatCurrent.GetStatValue(StatName.Speed));
            ChangeState(moveState);
        }

    }
}
