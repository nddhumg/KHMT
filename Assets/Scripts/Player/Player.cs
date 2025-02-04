using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	PlayerStateMachine state;
	Animator anim;
	[SerializeField] private SOStat stats;
	void Start(){
		state = new PlayerStateMachine (anim, this,stats);
		state.Initialize ();
	}

	void Update(){
		state.Update ();
	}

	void FixedUpdate(){
		state.FixedUpdate ();
	}
}
