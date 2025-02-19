using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState {
	protected float speed = 10;
	protected Vector3 position = Vector3.zero;

	public PlayerMovementState (PlayerStateMachine statePlayer, float speed) : base (statePlayer){
		this.speed = speed;
	}

	public float Speed{
		set{ 
			speed = value;
		}
	}
    public override void Enter()
    {
        base.Enter();
		this.playerState.Animator.SetBool(PlayerStateMachine.ParametersAnimator.isRun.ToString(),true);
    }

    public override void Exit()
    {
        base.Exit();
        this.playerState.Animator.SetBool(PlayerStateMachine.ParametersAnimator.isRun.ToString(), false);
    }

    public override void CheckChangeState()
    {
        base.CheckChangeState();
		if (JoyStick.instance.Direction == Vector2.zero)
		{
			this.playerState.ChangeState(playerState.idleStat);
		}
				
    }

    public override void UpdateLogic(){
        base.UpdateLogic();
		
        position = playerState.GetPosition();
		position.x += JoyStick.instance.Direction.x * Time.deltaTime * speed;
		position.y += JoyStick.instance.Direction.y * Time.deltaTime * speed;
		position.z = 0;
		playerState.Move (position);
	}
}
