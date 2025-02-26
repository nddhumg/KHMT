using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : Level {
	[SerializeField] protected uint exp = 0;
	[SerializeField] protected uint expLevelUp = 20;

	public void ExpUp(uint expUp){
		this.exp += expUp;
		if (this.exp >= expLevelUp) {
			LevelUp ();
            exp -= expLevelUp;
		}
	}
	[ButtonAttribute]
	public override bool LevelUp ()
	{
		if (base.LevelUp ()) {
			if (levelCurrent == 10) {
				expLevelUp = 40;
			}
			UpgradeSystem.instance.CreateUpgrade ();
			return true;
		}
		return false;
	}

}
