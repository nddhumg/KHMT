using EnumName;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ndd.Stat
{
    public interface IStat
    {
        public List<StatEntry> Stats { get; }
        public Action<StatName, float> OnStatUpdatedValue { get; set; }
        public Action<StatName, float> OnStatChangedValue { get; set; }
        public SOStat Clone();
        public StatEntry GetStatEntry(StatName statKey);
        public void Copy(IStat statCopy);
        public float GetStatValue(StatName statKey);
        public void SetStatValue(StatName statKey, float value);
        public void IncreaseStat(StatName statKey, float value, bool isDebug = true);
        public void PercentageIncreaseStat(StatName statKey, float value);
        public void AddStatValue(StatName statKey, float value);
        public void Add(IStat stat);
    }
}
