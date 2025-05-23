using System;
using System.Collections;
using System.Collections.Generic;
using EnumName;
using UnityEngine;
namespace EnumName
{
    public enum Stat
    {
        Hp,
        Speed,
        AttackRange,
        Damage,
        AttackRate,
        HpMax,
    }
}
[System.Serializable]
public class StatEntry
{
    public EnumName.Stat key;
    public float value;

    public StatEntry(Stat key, float value)
    {
        this.key = key;
        this.value = value;
    }
}

[CreateAssetMenu(fileName = "StatData", menuName = "SO/Stat")]
public class SOStat : ScriptableObject, IStat
{
    [SerializeField] private List<StatEntry> stats = new List<StatEntry>();

    public Action<Stat, float> OnChangeStat { get; set; }
    public List<StatEntry> Stats => stats;

    public static SOStat operator + (SOStat a, SOStat b)
    {
        SOStat result = a.Clone();
        foreach (StatEntry entry in b.Stats)
        {
            result.IncreaseStat(entry.key, entry.value);
        }

        return result;
    }


    public SOStat Clone()
    {
        SOStat result = ScriptableObject.CreateInstance<SOStat>();
        foreach (StatEntry entry in Stats)
        {
            result.stats.Add(new StatEntry(entry.key, entry.value));
        }
        return result;
    }

    public void Copy(IStat statCopy)
    {
        this.stats.Clear();
        foreach (StatEntry entry in statCopy.Stats)
        {
            this.stats.Add(new StatEntry(entry.key, entry.value));
        }
    }
    public float GetStatValue(Stat statKey)
    {
        try
        {
            return GetStatEntry(statKey).value;
        }
        catch
        {
            Debug.LogWarning("No " + statKey.ToString() + " in stat");
            return 0;
        }
    }

    public void SetStatValue(Stat statKey, float value)
    {

        try
        {
            GetStatEntry(statKey).value = value;
        }
        catch
        {
            stats.Add(new StatEntry(statKey, value));
            Debug.LogWarning("Create stat :" + statKey.ToString());
        }
        if (statKey == Stat.Hp)
        {
            NormalizeHp();
        }
        OnChangeStat?.Invoke(statKey, GetStatValue(statKey));
    }

    public void IncreaseStat(Stat statKey, float value)
    {
        try
        {
            GetStatEntry(statKey).value += value;
        }
        catch
        {
            stats.Add(new StatEntry(statKey, value));
            Debug.LogWarning("Create stat :" + statKey.ToString());
        }
        if (statKey == Stat.Hp)
        {
            NormalizeHp();
        }
        OnChangeStat?.Invoke(statKey, GetStatValue(statKey));
    }

    public void PercentageIncreaseStat(Stat statKey, float value)
    {
        try
        {
            StatEntry entry = GetStatEntry(statKey);
            entry.value += entry.value * value / 100;
            if (statKey == Stat.Hp)
            {
                NormalizeHp();
            }
            OnChangeStat?.Invoke(statKey, GetStatValue(statKey));
        }
        catch
        {
            Debug.LogWarning("No stat " + statKey.ToString());
        }

    }

    protected StatEntry GetStatEntry(Stat statKey)
    {
        foreach (StatEntry stat in stats)
        {
            if (stat.key == statKey)
                return stat;
        }

        return null;
    }

    protected void NormalizeHp()
    {
        float hp = -1, hpmax = -1;
        foreach (StatEntry stat in stats)
        {
            if (stat.key == Stat.Hp)
            {
                hp = stat.value;
            }
            else if (stat.key == Stat.HpMax)
            {
                hpmax = stat.value;
            }
        }
        if (hp > hpmax && hp != -1 && hpmax != -1)
        {
            GetStatEntry(Stat.Hp).value = hpmax;
        }
    }

    public void AddStatValue(Stat statKey, float value)
    {
        if (GetStatEntry(statKey) == null)
        {
            stats.Add(new StatEntry(statKey, value));
        }
        else
        {
            Debug.LogWarning("Stats already contains " + statKey.ToString());
        }
    }

    public void Add(IStat stats)
    {
        foreach (StatEntry stat in stats.Stats) {
            IncreaseStat(stat.key, stat.value);
        }
    }
}


