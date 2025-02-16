using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IReceiveDamage {
	protected EnemyStateManager state;
	protected Transform player;
	[SerializeField] protected SOStat stat;
 	protected float hp;
	protected float hpMax;

	[SerializeField] protected DropItem dropItem;

	void Start(){
		player = Player.instance.transform;
		state.Initialize ();
		hpMax = stat.GetStatValue (EnumName.Stat.Hp);
		hp = hpMax;
	}

	protected virtual void Update(){
        state.Update ();
	}

	void FixedUpdate(){
		state.FixedUpdate ();
	}

	public Transform GetPlayer(){
		return player;
	}

	public void TakeDamage(int damage){
		hp -= damage;
		if (hp <= 0) {
			Dead ();
		}
	}

	protected  void Dead(){
		hp = hpMax;
		dropItem.Drop (transform.position, Quaternion.identity);
		gameObject.SetActive (false);
	}
}
