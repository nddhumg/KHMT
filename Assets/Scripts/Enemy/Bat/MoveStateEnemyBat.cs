using Core.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemies
{
    public class MoveStateEnemyBat : EnemyState
    {
        private IEnemyMeleeStateManager enemyStateManager;
        private Vector2 direction;
        private float speed = 100;
        public MoveStateEnemyBat(StateManager stateManager,IEnemyMeleeStateManager enemyMeleeStateManager, float speed) : base(stateManager)
        {
            this.enemyStateManager = enemyMeleeStateManager;
            this.speed = speed; 
        }

        public override void Enter()
        {
            base.Enter();
            direction = enemyStateManager.GetDirecTionToPlayer();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            enemyStateManager.SetPosition(speed * Time.deltaTime * direction  + (Vector2)enemyStateManager.GetPosition() );
        }
    }
}
