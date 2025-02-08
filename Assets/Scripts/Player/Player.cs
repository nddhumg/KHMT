using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	PlayerStateMachine state;
	Animator anim;
	[SerializeField] private SOStat stats;
	[SerializeField] private PlayerLevel level;

	public PlayerLevel Level{
		get{ 
			return level;
		}
	}
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

	void OnTriggerEnter2D(Collider2D col){
		IItemPickUp item = col.GetComponent<IItemPickUp> ();
		if (item != null)
			item.PickUp ();
	}

}
