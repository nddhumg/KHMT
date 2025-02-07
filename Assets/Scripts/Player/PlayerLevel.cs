using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : Level {
	protected uint exp = 0;
	[SerializeField]protected uint expLevelUp;

	public void ExpUp(uint exp){
		this.exp += exp;
		if (exp >= expLevelUp) {
			LevelUp ();
			exp -= expLevelUp;
		}
	}
	[ButtonAttribute]
	public override bool LevelUp ()
	{
		if (base.LevelUp ()) {
//			UpgradeSystem.instance.CreateUpgrade ();
			return true;
		}
		return false;
	}

}
