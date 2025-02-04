using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageAmount : MonoBehaviour ,ISetStat{
	[SerializeField] protected float damage;

	void OnTriggerEnter2D(Collider2D col){
		IReceiveDamage receive = col.GetComponent<IReceiveDamage> ();
		receive.TakeDamage (damage);
	}

	public void SetStat(SOStat stat){
		damage = stat.GetStatValue (EnumName.Stat.Damage);
	}
}
