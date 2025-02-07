using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradeSkill", menuName = "SO/Upgrade/Skill")]
public class SOUpgradeSkill : ScriptableObject,IUpgrade {
	[SerializeField] protected GameObject prefab;
	[SerializeField] protected SOUpgradeInfo[] info;

	public SOUpgradeInfo[] Info{
		get{ 
			return info;
		}
	}

	public Level Upgrade(){
		return Instantiate (prefab).GetComponentInChildren<Level>();
	}
}
