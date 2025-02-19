using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IReceiveDamage
{
    [SerializeField] protected SOStat statBase;
    protected List<StatEntry> statCurrent;
    public Action<EnumName.Stat, float> OnStatChange;
    public List<StatEntry> StatCurrent => StatCurrent;
    public float GetStatValue(EnumName.Stat statKey)
    {
        try
        {
            StatEntry stat = GetStat(statKey);
            return stat.value;
        }
        catch
        {
            Debug.LogWarning("No stat " + statKey.ToString());
            return -1f;
        }
    }

    public void SetStatValue(EnumName.Stat statKey, float value) {
        try
        {
            StatEntry stat = GetStat(statKey);
            stat.value = value;
            OnStatChange?.Invoke(statKey, value);
        }
        catch
        {
            Debug.LogWarning("No stat " + statKey.ToString());
        }
    }

    public void IncreaseStat(EnumName.Stat statKey, float value)
    {
        try
        {
            if (statKey == EnumName.Stat.Hp)
            {
                float hpMax = GetStatValue(EnumName.Stat.HpMax);
                StatEntry statHp = GetStat(statKey);
                statHp.value += value;
                if (statHp.value > hpMax)
                    statHp.value = hpMax;
                OnStatChange?.Invoke(statKey, statHp.value);
            }
            else
            {
                StatEntry stat = GetStat(statKey);
                stat.value += value;
                OnStatChange?.Invoke(statKey, stat.value);
            }
        }
        catch {
            Debug.LogWarning("No stat " + statKey.ToString());
        }
    }

    public void PercentageIncreaseStat(EnumName.Stat statKey, float value)
    {
        try
        {
            StatEntry stat;
            if (statKey == EnumName.Stat.Hp)
            {
                stat = GetStat(statKey);
                float hpMax = GetStatValue(EnumName.Stat.HpMax);
                stat.value += stat.value * value / 100;
                if (stat.value > hpMax)
                    stat.value = hpMax;
            }
            else
            {
                stat = GetStat(statKey);
                stat.value += stat.value * value / 100;
                OnStatChange?.Invoke(statKey, stat.value);
            }
        }
        catch
        {
            Debug.LogWarning("No stat " + statKey.ToString());
        }
    }


    public void TakeDamage(int damage)
    {
        IncreaseStat(EnumName.Stat.Hp, -damage);
    }

    protected StatEntry GetStat(EnumName.Stat statKey)
    {
        foreach (StatEntry stat in statCurrent)
        {
            if (stat.key == statKey)
                return stat;
        }
        Debug.LogWarning("No stat " + statKey.ToString());
        return null;
    }
    private void Awake()
    {
        SOStat statTemp  = Instantiate(statBase);
        statCurrent = new List<StatEntry> (statTemp.Stats);
        statCurrent.Add(new StatEntry(EnumName.Stat.Hp, GetStatValue(EnumName.Stat.HpMax)));
    }


}
