using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	PlayerStateMachine state;
	Animator anim;
	[SerializeField] private PlayerLevel level;
	[SerializeField] private PlayerStat statManager;
	private int hp;

	public PlayerLevel Level{
		get{ 
			return level;
		}
	}

	public PlayerStat StatsManager => statManager;

    void Start(){
		state = new PlayerStateMachine (anim, this, statManager);
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
