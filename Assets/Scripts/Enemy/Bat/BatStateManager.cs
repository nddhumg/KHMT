using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemies
{
    public class BatStateManager : EnemyStateManager
    {
        IState moveState;

        public BatStateManager(Enemy enemy) : base(enemy)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            moveState = new MoveStateEnemyBat(this,enemy.Stat.GetStatValue(EnumName.Stat.Speed));
            ChangeState(moveState);
        }
    }
}
