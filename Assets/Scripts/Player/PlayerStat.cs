using System;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

public class PlayerStat : MonoBehaviour, IReceiveDamage
{
    [SerializeField] protected SOStat statBase;
    protected SOStat statCurrent;

    public SOStat StatCurrent => statCurrent;



    public void TakeDamage(int damage)
    {
        statCurrent.IncreaseStat(EnumName.Stat.Hp, -damage);
    }

    private void Awake()
    {
        statCurrent = statBase.Copy();
        statCurrent.Stats.Add(new StatEntry(EnumName.Stat.Hp, statBase.GetStatValue(EnumName.Stat.HpMax)));
    }



}
