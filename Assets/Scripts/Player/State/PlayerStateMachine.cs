using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : StateManager {
	public PlayerMovementState moveState;
	public PlayerIdleStat idleStat;
	protected PlayerStat stats;

	protected Animator animator;
	protected Player player;

	public Animator Animator => animator;

	public enum ParametersAnimator { 
		isRun,
	}
	public PlayerStateMachine(Animator animator,Player player, PlayerStat stats){
		this.animator = animator;
		this.player = player;
		this.stats = stats;
	}

	public override void Initialize ()
	{
		moveState = new PlayerMovementState (this,stats.StatCurrent.GetStatValue(EnumName.Stat.Speed));
		idleStat = new PlayerIdleStat(this);
		stateCurrent = idleStat;
		stateCurrent.Enter ();
	}

	public void Move(Vector3 position){
		player.transform.position = position;
	}

	public Vector3 GetPosition(){
		return player.transform.position;
	}

	public void SetSpeed(float value){
		moveState.Speed = value;
	}

}
