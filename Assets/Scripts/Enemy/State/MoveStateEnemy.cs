using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class MoveStateEnemy : EnemyState
    {
        protected float speed = 10f;
        protected Vector3 position;
        protected int direction = 1;
        protected Vector3 directionToPlayer = new Vector3();

        public MoveStateEnemy(EnemyStateManager enemyState, float speed) : base(enemyState)
        {
            this.speed = speed;
        }

        public override void Enter()
        {
            direction = enemyState.Enemy.GetDirectionLook();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            directionToPlayer = (enemyState.GetPositionPlayer() - enemyState.GetPosition()).normalized;
            if (directionToPlayer.x > 0)
            {
                if (direction != 1)
                {
                    direction = 1;
                    enemyState.Enemy.Flip();
                }
            }
            else if (directionToPlayer.x < 0)
            {
                if (direction != -1)
                {
                    direction = -1;
                    enemyState.Enemy.Flip();
                }
            }

            position = enemyState.GetPosition();
            position += speed * Time.deltaTime * directionToPlayer;

            enemyState.SetPosition(position);
        }
    }
}