using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSkillRate : ChestRate
{
    private SOUpgradeSkill skillUpgrade;
    public ChestSkillRate(float rate) : base(rate)
    {
    }

    public override void GenerateChestReward()
    {
        skillUpgrade.ApplyUpgrade();
    }

    public override Sprite GetIcon()
    {
        skillUpgrade = UpgradeSystem.instance.GetRandomUpgradeSkill();
        return skillUpgrade.Icon;
    }

    public override string GetStringValue()
    {
        return string.Empty;
    }
}
