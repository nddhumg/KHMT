using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	PlayerStateMachine state;
	Animator anim;

	void Start(){
		state = new PlayerStateMachine (anim, this);
		state.Initialize ();
	}

	void Update(){
		state.Update ();
	}

	void FixedUpdate(){
		state.FixedUpdate ();
	}
}
