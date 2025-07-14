using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;


namespace Core.Enemies
{
    public class BatStateManager : EnemyStateManager, IEnemyMeleeStateManager
    {
        IState moveState;
        public IState MoveState => moveState;
        public BatStateManager(Enemy enemy) : base(enemy)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            moveState = new MoveStateEnemyBat(this, this, enemy.StatCurrent.GetStatValue(StatName.Speed));
            ChangeState(moveState);
        }
    }
}
