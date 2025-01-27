using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState {
	private float speed = 10;
	private Vector3 position = Vector3.zero;
	private Vector2 directionInput;

	public PlayerMovementState (PlayerStateMachine statePlayer) : base (statePlayer){}

	public override void UpdateLogic(){
		directionInput = JoyStick.instance.Direction;
		if (directionInput == Vector2.zero) {
			playerState.ChangeState (playerState.idleState);
		}
		position = playerState.GetPosition();
		position.x += directionInput.x * Time.deltaTime * speed;
		position.y += directionInput.y * Time.deltaTime * speed;
		position.z = 0;
		playerState.Move (position);
	}
}
