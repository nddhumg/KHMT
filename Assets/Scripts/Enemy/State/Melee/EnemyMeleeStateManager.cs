using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class EnemyMeleeStateManager : EnemyStateManager
    {
        public IState moveState;

        public EnemyMeleeStateManager(Enemy enemy) : base(enemy)
        {

        }


        public override void Initialize()
        {
            base.Initialize();
            moveState = new MoveStateEnemy(this, enemy.Stat.GetStatValue(EnumName.Stat.Speed));
            ChangeState(moveState);
        }

    }
}
