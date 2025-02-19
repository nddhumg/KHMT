using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

public abstract class EnemyStateManager : StateManager {
	protected Enemy enemy;
	protected SOStat stat;

	public Enemy Enemy => enemy;

	public EnemyStateManager(Enemy enemy,SOStat stat){
		this.enemy = enemy;
		this.stat = stat;
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

	public Vector3 GetDirecTionToPlayer() {
		return (GetPositionPlayer() - GetPosition()).normalized;
	}
}
