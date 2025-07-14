using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class MoveStateEnemy : EnemyState
    {
        protected IEnemyStateManager enemyStateManager;
        protected float speed = 10f;
        protected Vector3 position;
        protected int direction = 1;
        protected Vector3 directionToPlayer = new Vector3();

        public MoveStateEnemy(StateManager stateManager, IEnemyStateManager enemyStateManager, float speed) : base(stateManager)
        {
            this.enemyStateManager = enemyStateManager;
            this.speed = speed;
        }

        public override void Enter()
        {
            direction = enemyStateManager.Enemy.GetDirectionLook();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            directionToPlayer = (enemyStateManager.GetPositionPlayer() - enemyStateManager.GetPosition()).normalized;
            if (directionToPlayer.x > 0)
            {
                if (direction != 1)
                {
                    direction = 1;
                    enemyStateManager.Enemy.Flip();
                }
            }
            else if (directionToPlayer.x < 0)
            {
                if (direction != -1)
                {
                    direction = -1;
                    enemyStateManager.Enemy.Flip();
                }
            }

            position = enemyStateManager.GetPosition();
            position += speed * Time.deltaTime * directionToPlayer;

            enemyStateManager.SetPosition(position);
        }
    }
}