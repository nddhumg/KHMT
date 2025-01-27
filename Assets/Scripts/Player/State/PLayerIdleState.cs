using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerIdleState : PlayerState {
	
	public PLayerIdleState (PlayerStateMachine statePlayer) : base (statePlayer){
		
	}

	public override void UpdateLogic(){
		if (JoyStick.instance.Direction != Vector2.zero) {
			playerState.ChangeState (playerState.moveState);
		}
	}
}
