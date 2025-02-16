using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour  {
	[SerializeField] protected int damage = 1;

	public void SetDamage(int value) {
		damage = value;
	}

	void OnTriggerEnter2D(Collider2D col) {
		IReceiveDamage receive = col.GetComponent<IReceiveDamage>();
		Send(receive);

    }
	protected virtual bool Send(IReceiveDamage receive) {
		if (receive == null)
			return false;
		receive.TakeDamage(damage);
		return true;
	}

}
