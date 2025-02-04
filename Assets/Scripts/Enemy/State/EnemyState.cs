using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : IState {
	protected EnemyStateManager enemyState;

	public EnemyState(EnemyStateManager enemyState){
		this.enemyState = enemyState;
	}

	public virtual void Enter(){

	}

	public virtual void Exit (){

	}

	public virtual void UpdateLogic(){

	}

	public virtual void UpdatePhysics(){

	}
}
