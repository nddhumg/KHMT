using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : Singleton<UpgradeSystem> {
	[SerializeField] protected List<UpgradeSelect> upgradesSelectScript;
	[SerializeField] protected List<SOUpgradeSkill> allsUpgradeSkill;
	[SerializeField] protected List<SOUpgradeStat> allsUpgradeStat;
	protected IUpgrade[] upgradesSelect = new IUpgrade[3] {null,null,null};
	protected Dictionary<IUpgrade,Level> activeUpgrades = new Dictionary<IUpgrade,Level>();

	void Start(){
		SetActiveUpgrade (false);
	}

	public virtual void CreateUpgrade(){
		SetActiveUpgrade (true);
		List<SOUpgradeSkill> upgradesSkill = new List<SOUpgradeSkill>(allsUpgradeSkill);
		List<SOUpgradeStat> upgradesStat = new List<SOUpgradeStat>(allsUpgradeStat);
		SOUpgradeInfo[] infoArray = new SOUpgradeInfo[3];
		int random;
		int countUpgradeSelect = 0;
		foreach (UpgradeSelect select in upgradesSelectScript) {
			if (Random.value > 0.5) {
				random = Random.Range (0, upgradesSkill.Count);
				Level levelScript = activeUpgrades [upgradesSkill [random]];
				if (!levelScript.CanLevelUp ()) {
					allsUpgradeSkill.RemoveAt (random);
					upgradesSkill.RemoveAt (random);
					return;
				}
				upgradesSelect[countUpgradeSelect] = upgradesSkill [random];
				infoArray [countUpgradeSelect] = upgradesSkill [random].Info [levelScript.LevelCurrent];
			} 
			else {
				random = Random.Range (0, upgradesStat.Count);
				upgradesSelect[countUpgradeSelect] = upgradesStat [random];
				infoArray [countUpgradeSelect] = upgradesStat [random].Info;
			}
			countUpgradeSelect++;
		}
		for (int option = 0; option <= 3; option++) {
			upgradesSelectScript [option].SetInfo ((uint)option, infoArray [option].Icone, infoArray [option].Text);
		}
	}

	private void SetActiveUpgrade(bool isActive){
		foreach (UpgradeSelect upgrade in upgradesSelectScript) {
			upgrade.gameObject.SetActive (isActive);
		}
	}

	public void ApllyUpgrade(uint index){
		SetActiveUpgrade (false);
		IUpgrade upgradeSelect = upgradesSelect [index];
		if (activeUpgrades.ContainsKey (upgradeSelect)) {
			activeUpgrades [upgradeSelect].LevelUp ();
			return;
		}
		Level levelSkill = upgradeSelect.Upgrade();
		if (levelSkill != null) {
			activeUpgrades.Add (upgradeSelect, levelSkill);
		}
	}

}
