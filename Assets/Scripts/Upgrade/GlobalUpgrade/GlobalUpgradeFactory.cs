using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;
using Ndd.Stat;

public class GlobalUpgradeFactory
{

    protected IStat statBonus;
    protected Dictionary<(string, int), IGlobalUpgradeEffect> upgradeEffect;
    protected Dictionary<string ,IUpgradeOnStart> upgradesOnStart;
    public GlobalUpgradeFactory(IStat statBonus, Dictionary<string, IUpgradeOnStart> upgradesOnStart)
    {
        this.statBonus = statBonus;
        upgradeEffect = new Dictionary<(string, int), IGlobalUpgradeEffect>();
        this.upgradesOnStart = upgradesOnStart;
        AddSpecialUpgrade();
        AddStatUpgrade();
    }

    private void AddStatUpgrade()
    {
        upgradeEffect.Add((GlobalUpgradeName.DamageBoost.ToString(), 1), new GlobalStatModifier(statBonus, StatName.Damage, 10));
        upgradeEffect.Add((GlobalUpgradeName.DamageBoost.ToString(), 2), new GlobalStatModifier(statBonus, StatName.Damage, 20));
        upgradeEffect.Add((GlobalUpgradeName.DamageBoost.ToString(), 3), new GlobalStatModifier(statBonus, StatName.Damage, 30));
    }

    private void AddSpecialUpgrade()
    {
        upgradeEffect.Add((GlobalUpgradeName.FinalMercy.ToString(), 1), new GlobalSpecial(upgradesOnStart, new FinalMercy(), GlobalUpgradeName.FinalMercy.ToString()));
        upgradeEffect.Add((GlobalUpgradeName.FirstStepPower.ToString(), 1), new GlobalSpecial(upgradesOnStart, new StartGameLevelBoost(), GlobalUpgradeName.FirstStepPower.ToString()));
    }
        
    public IGlobalUpgradeEffect GetUpgradeEffect(string name, int level)
    {
        if (upgradeEffect.TryGetValue((name, level), out IGlobalUpgradeEffect effect))
        {
            return effect;
        }
        else
        {
            Debug.LogWarning($"No upgrade effect found for model: {name} at level: {level}");
            return null;
        }
    }
}
