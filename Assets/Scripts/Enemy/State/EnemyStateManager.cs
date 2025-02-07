using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

public class EnemyStateManager : StateManager {
	protected Enemy enemy;
	public IState moveState;
	public IState attackState;
	protected SOStat stat;

	public EnemyStateManager(Enemy enemy,SOStat stat){
		this.enemy = enemy;
		this.stat = stat;
	}

	public override void Initialize ()
	{
		moveState = new MoveStateEnemy (this, stat.GetStatValue(Stat.Speed), stat.GetStatValue(Stat.AttackRange));
		attackState = new AttackStateEnemy (this);
		stateCurrent = moveState;
		stateCurrent.Enter ();
	}

	public override void ResetState ()
	{
		stateCurrent = moveState;
		stateCurrent.Enter ();
	}


	public void MoveTo(Vector3 position){
		enemy.transform.position = position;
	}

	public Vector3 GetPosition(){
		return enemy.transform.position;
	}

	public Vector3 GetPositionPlayer(){
		return enemy.GetPlayer ().position;
	}

	public bool IsInAttackRange(){
		return Vector2.Distance (GetPosition (), GetPositionPlayer ()) <= stat.GetStatValue (Stat.AttackRange);
	}
}
