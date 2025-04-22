using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkillComponent 
{
    [SerializeField] protected float damageMultiplier = 1;
    protected SOStat statPlayer;

    public float DamageMultiplier => damageMultiplier;

    public DamageSkillComponent(float damageMultiplier, SOStat stat)
    {
        this.damageMultiplier = damageMultiplier;
        this.statPlayer = stat;
    }

    public virtual void IncreaseDamageMultiplier(float value)
    {
        damageMultiplier += value;
    }

    public virtual void SetDamageMultiplier(float value)
    {
        damageMultiplier = value;
    }

    public virtual int GetDamge()
    {
        return (int)(statPlayer.GetStatValue(EnumName.Stat.Damage) * damageMultiplier);
    }

}
