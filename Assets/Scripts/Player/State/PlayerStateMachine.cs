using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : StateManager {
	public PlayerMovementState moveState;

	protected Animator animator;
	protected Player player;
	protected StatsManager stats;


	public PlayerStateMachine(Animator animator,Player player,StatsManager stats){
		this.animator = animator;
		this.player = player;
		this.stats = stats;
	}

	public override void Initialize ()
	{
		moveState = new PlayerMovementState (this,stats.GetStatValue(EnumName.Stat.Speed));
		stateCurrent = moveState;
		stateCurrent.Enter ();
		stats.ChangeStat += ChangeStat;
	}

	public void Move(Vector3 position){
		player.transform.position = position;
	}

	public Vector3 GetPosition(){
		return player.transform.position;
	}

	public void ChangeStat(EnumName.Stat statChange,float value){
		if (statChange == EnumName.Stat.Speed) {
			moveState.Speed = value;
		}
	}
}
