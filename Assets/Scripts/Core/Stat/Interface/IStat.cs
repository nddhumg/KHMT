using EnumName;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IStat
{
    public List<StatEntry> Stats { get; }
    public Action<Stat, float> OnChangeStat { get; set; }
    public SOStat Clone();
    public void Copy(IStat statCopy);
    public float GetStatValue(Stat statKey);
    public void SetStatValue(Stat statKey, float value);
    public void IncreaseStat(Stat statKey, float value);
    public void PercentageIncreaseStat(Stat statKey, float value);
    public void AddStatValue(Stat statKey, float value);
    public void Add(IStat stat);
}
