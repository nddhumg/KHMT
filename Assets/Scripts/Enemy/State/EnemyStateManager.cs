using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;
namespace Core.Enemies
{
	public abstract class EnemyStateManager : StateManager, IEnemyStateManager
	{
		protected Enemy enemy;

		public Enemy Enemy => enemy;

		public EnemyStateManager(Enemy enemy)
		{
			this.enemy = enemy;
		}

		public void SetPosition(Vector3 position)
		{
			enemy.transform.position = position;
		}

        public void SetPosition(Vector2 position)
        {
            enemy.transform.position = position;
        }

        public Vector3 GetPosition()
		{
			return enemy.transform.position;
		}

		public Vector3 GetPositionPlayer()
		{
			return enemy.GetPlayer().position;
		}

		public Vector3 GetDirecTionToPlayer()
		{
			return (GetPositionPlayer() - GetPosition()).normalized;
		}
	}
}