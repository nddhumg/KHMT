using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ObjectHandler {
	protected Vector2 attackDirection = Vector2.down;
	[SerializeField] protected SOStat stats;

	void OnValidate(){
		actionDelay = stats.GetStatValue (EnumName.Stat.AttackRate);
	}
	protected override void Update(){
		base.Update ();
		if(JoyStick.instance.Direction != Vector2.zero)
			attackDirection = JoyStick.instance.Direction;
	}
	protected virtual void Start(){
		attackDirection = Vector2.down;
	}
	protected override void HandleObject (){
		
	}
		
}
