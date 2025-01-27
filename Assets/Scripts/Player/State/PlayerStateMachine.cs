using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateManager {
	protected Animator animator;
	private Player player;
	public IState moveState;
	public IState idleState;


	public PlayerStateMachine(Animator animator,Player player){
		this.animator = animator;
		this.player = player;
		moveState = new PlayerMovementState (this);
		idleState = new PLayerIdleState (this);
		stateCurrent = idleState;
	}

	public override void Initialize ()
	{
		stateCurrent = idleState;
		stateCurrent.Enter ();
	}

	public void Move(Vector3 position){
		player.transform.position = position;
	}

	public Vector3 GetPosition(){
		return player.transform.position;
	}
}
