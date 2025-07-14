using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;
using Ndd.Stat;
public class GlobalStatModifier : IGlobalUpgradeEffect
{
    protected IStat stat;
    protected StatName statBonus;
    protected float modifierValue;
    public GlobalStatModifier(IStat stat, StatName statBonus, float value)
    {
        this.stat = stat;
        this.statBonus = statBonus;
        this.modifierValue = value;
    }

    public void ApplyEffect()
    {
        stat.IncreaseStat(statBonus, modifierValue, false);
    }

    public void RevertEffect()
    {
        stat.IncreaseStat(statBonus, -modifierValue);
    }
}
