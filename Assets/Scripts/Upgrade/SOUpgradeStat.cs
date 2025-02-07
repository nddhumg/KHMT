using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

[CreateAssetMenu(fileName = "UpgradeStat", menuName = "SO/Upgrade/Stat")]
public class SOUpgradeStat : ScriptableObject,IUpgrade {
	[SerializeField] protected Stat statUpgrade;
	[SerializeField] protected int upgradeValue;
	[SerializeField] protected SOUpgradeInfo info;

	public SOUpgradeInfo Info{
		get{ 
			return info;
		}
	}

	public Level Upgrade(){
		Player.instance.SetStat (upgradeValue);
		return null;
	}
}
