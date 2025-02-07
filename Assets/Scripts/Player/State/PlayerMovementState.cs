using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState {
	protected float speed = 10;
	protected Vector3 position = Vector3.zero;
	protected Vector2 directionInput;

	public PlayerMovementState (PlayerStateMachine statePlayer, float speed) : base (statePlayer){
		this.speed = speed;
	}

	public float Speed{
		set{ 
			speed = value;
		}
	}

	public override void UpdateLogic(){
		directionInput = JoyStick.instance.Direction;
		position = playerState.GetPosition();
		position.x += directionInput.x * Time.deltaTime * speed;
		position.y += directionInput.y * Time.deltaTime * speed;
		position.z = 0;
		playerState.Move (position);
	}
}
