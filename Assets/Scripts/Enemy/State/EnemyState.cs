using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
	public abstract class EnemyState : IState
	{
		protected EnemyStateManager enemyState;

		public EnemyState(EnemyStateManager enemyState)
		{
			this.enemyState = enemyState;
		}

		public virtual void CheckChangeState()
		{
		}

		public virtual void Enter()
		{

		}

		public virtual void Exit()
		{

		}

		public virtual void UpdateLogic()
		{
			CheckChangeState();

		}

		public virtual void UpdatePhysics()
		{

		}
	}
}