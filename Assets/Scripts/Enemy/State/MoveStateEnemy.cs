using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateEnemy : EnemyState {
	protected float speed = 10f;
	protected Vector3 position;

	public MoveStateEnemy (EnemyStateManager enemyState, float speed) : base (enemyState){
		this.speed = speed;
	}

	public override void Enter ()
	{
	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();
		position = enemyState.GetPosition ();
		position -= speed * Time.deltaTime * (enemyState.GetPosition () - enemyState.GetPositionPlayer ()).normalized;
		enemyState.MoveTo (position);
	}
}
