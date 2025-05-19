using Core.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemies
{
    public class MoveStateEnemyBat : EnemyState
    {
        private Vector2 direction;
        private float speed = 100;
        public MoveStateEnemyBat(EnemyStateManager enemyState, float speed) : base(enemyState)
        {
            this.speed = speed; 
        }

        public override void Enter()
        {
            base.Enter();
            direction = enemyState.GetDirecTionToPlayer();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            enemyState.SetPosition(speed * Time.deltaTime * direction  + (Vector2)enemyState.GetPosition() );
        }
    }
}
