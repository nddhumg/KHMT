using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : StateManager {
	protected Animator animator;
	protected Player player;
	protected SOStat stats;
	public IState moveState;


	public PlayerStateMachine(Animator animator,Player player, SOStat stats){
		this.animator = animator;
		this.player = player;
		this.stats = stats ;
		moveState = new PlayerMovementState (this,stats.GetStatValue(EnumName.Stat.Speed));
	}

	public override void Initialize ()
	{
		stateCurrent = moveState;
		stateCurrent.Enter ();
	}

	public void Move(Vector3 position){
		player.transform.position = position;
	}

	public Vector3 GetPosition(){
		return player.transform.position;
	}
}
