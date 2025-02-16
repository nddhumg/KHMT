using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : StateManager {
	public PlayerMovementState moveState;
	protected PlayerStat stats;

	protected Animator animator;
	protected Player player;


	public PlayerStateMachine(Animator animator,Player player, PlayerStat stats){
		this.animator = animator;
		this.player = player;
		this.stats = stats;
	}

	public override void Initialize ()
	{
		moveState = new PlayerMovementState (this,stats.GetStatValue(EnumName.Stat.Speed));
		stateCurrent = moveState;
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
