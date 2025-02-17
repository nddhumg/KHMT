using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeSystem : Singleton<UpgradeSystem> {
	[SerializeField] protected List<UpgradeSelect> upgradesSelect;
	[SerializeField] protected SOUpgrade[] availableUpgrades;
	protected int countUpgradeSelect = 3;
	protected List<SOUpgrade> infoUpgradeSelect = new List<SOUpgrade>();

	void Start()
	{
		SetActiveUpgrade(false);
	}

	public virtual void CreateUpgrade()
	{
	
		List<SOUpgrade> available = new List<SOUpgrade>(availableUpgrades);

        System.Random random = new ();
		infoUpgradeSelect.Clear();
        for (int i = 0; i < countUpgradeSelect; i++)
        {
            int index = random.Next(available.Count);
            infoUpgradeSelect.Add(available[index]);
            available.RemoveAt(index); 
        }
        for (int i = 0; i < countUpgradeSelect; i++)
        {
			upgradesSelect[i].SetInfo(i, infoUpgradeSelect[i].Icon, infoUpgradeSelect[i].GetDescription());
        }
        SetActiveUpgrade (true);
    }

	private void SetActiveUpgrade(bool isActive)
	{
		foreach (UpgradeSelect upgrade in upgradesSelect)
		{
			upgrade.gameObject.SetActive(isActive);
		}
	}

	public void ApllyUpgrade(int index)
	{
		infoUpgradeSelect[index].ApplyUpgrade();
        SetActiveUpgrade(false);

    }

}
