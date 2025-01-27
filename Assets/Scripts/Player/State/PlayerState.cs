using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : IState {
	protected PlayerStateMachine playerState;

	public PlayerState(PlayerStateMachine playerState){
		this.playerState = playerState;
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

