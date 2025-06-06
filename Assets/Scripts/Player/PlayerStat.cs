using System;
using System.Collections.Generic;
using UnityEngine;
using EnumName;

public class PlayerStat : MonoBehaviour, IReceiveDamage
{
    protected IStat statBase;
    protected IStat statCurrent;

    public IStat StatCurrent => statCurrent;

    public void TakeDamage(int damage)
    {
        statCurrent.IncreaseStat(Stat.Hp, -damage);
    }


    private void Awake()
    {
        statBase = GameController.instance.StatPlayer;
        statCurrent = statBase.Clone();
        statCurrent.Stats.Add(new StatEntry(Stat.Hp, statBase.GetStatValue(Stat.HpMax)));
    }



}
