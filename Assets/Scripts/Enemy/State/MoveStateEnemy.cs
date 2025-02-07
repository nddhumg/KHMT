using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateEnemy : EnemyState {
	protected float speed = 10f;
	protected float attackRange;
	protected Vector3 position;

	public MoveStateEnemy (EnemyStateManager enemyState, float speed, float attackRange) : base (enemyState){
		this.speed = speed;
		this.attackRange = attackRange;
	}

	public override void Enter ()
	{
	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();
		if (enemyState.IsInAttackRange()) {
			enemyState.ChangeState (enemyState.attackState);
			return;
		}
		position = enemyState.GetPosition ();
		position -= speed * Time.deltaTime * (enemyState.GetPosition () - enemyState.GetPositionPlayer ()).normalized;
		enemyState.MoveTo (position);
	}
}
