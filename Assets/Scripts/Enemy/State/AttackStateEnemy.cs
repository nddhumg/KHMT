using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy : EnemyState {
	protected bool isAttacking;

	public AttackStateEnemy (EnemyStateManager enemyState) : base (enemyState){
	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();
		if (!enemyState.IsInAttackRange ()) {
			enemyState.ChangeState (enemyState.moveState);
			return;
		}
	}
}
