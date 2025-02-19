using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : IState
{
	protected PlayerStateMachine playerState;

	public PlayerState(PlayerStateMachine playerState){
		this.playerState = playerState;
	}

    public virtual void CheckChangeState()
    {
    }

    public virtual void Enter(){

	}

	public virtual void Exit (){

	}

	public virtual void UpdateLogic(){
		CheckChangeState();

	}

	public virtual void UpdatePhysics(){

	}

}

