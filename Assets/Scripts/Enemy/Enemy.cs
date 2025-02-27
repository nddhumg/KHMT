using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IReceiveDamage {
	protected EnemyStateManager state;
	[SerializeField] protected Transform spriteTf;
	[SerializeField] protected SOStat stat;
 	protected float hp;
	protected float hpMax;

	[SerializeField] protected DropItem dropItem;

	public void Flip()
	{
        spriteTf.localScale = new Vector3(-1 * spriteTf.localScale.x, spriteTf.localScale.y, spriteTf.localScale.z);
    }

	public int GetDirectionLook() {
		return spriteTf.localScale.x > 0 ? 1 : -1; 
	}

    void Start(){
		state.Initialize ();
		hpMax = stat.GetStatValue (EnumName.Stat.HpMax);
		hp = hpMax;
	}

	protected virtual void Update(){
        state.Update ();
	}

	void FixedUpdate(){
		state.FixedUpdate ();
	}

	public Transform GetPlayer(){
		return Player.instance.transform;
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
		EnemySpawn.instance.EnemyCount--;
	}
}
