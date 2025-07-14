using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSkillRate : IChestRate
{
    private SOUpgradeSkill skillUpgrade;
    public void GenerateChestReward()
    {
        skillUpgrade.ApplyUpgrade(Player.instance);
    }

    public Sprite GetIcon()
    {
        skillUpgrade = UpgradeSystem.instance.GetRandomUpgradeSkill();
        return skillUpgrade.Icon;
    }

    public string GetStringValue()
    {
        return string.Empty;
    }
}
