using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IReceiveDamage {
	protected EnemyStateManager state;
	protected Transform player;
	[SerializeField] protected SOStat stat;
 	protected float hp;
	protected float hpMax;


	void Awake(){
		state = new EnemyStateManager (this,stat);
	}
	void Start(){
		player = Player.instance.transform;
		state.Initialize ();
		hpMax = stat.GetStatValue (EnumName.Stat.Hp);
		hp = hpMax;
	}

	void Update(){
		state.Update ();
	}

	void FixedUpdate(){
		state.FixedUpdate ();
	}

	public Transform GetPlayer(){
		return player;
	}

	public void TakeDamage(float damage){
		hp -= damage;
		Debug.Log (hp);
		if (hp <= 0) {
			Dead ();
		}
	}

	protected  void Dead(){
		hp = hpMax;
		gameObject.SetActive (false);
	}
}
