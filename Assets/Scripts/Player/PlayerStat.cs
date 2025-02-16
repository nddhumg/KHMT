using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IReceiveDamage
{
    [SerializeField] protected SOStat statBase;
    protected List<StatEntry> statCurrent;
    public Action<EnumName.Stat, float> OnStatChange;
    public List<StatEntry> StatCurrent => StatCurrent;
    public float GetStatValue(EnumName.Stat statKey)
    {
        foreach (StatEntry stat in statCurrent)
        {
            if (stat.key == statKey)
                return stat.value;
        }
        Debug.LogWarning("No stat " + statKey.ToString());
        return -1f;
    }

    public void SetStatValue(EnumName.Stat statKey, float value) {
        foreach (StatEntry stat in statCurrent)
        {
            if (stat.key == statKey)
            {
                stat.value = value;
                OnStatChange?.Invoke(statKey, value);
            }
        }
        Debug.LogWarning("No stat " + statKey.ToString());
    }

    public void IncreaseStat(EnumName.Stat statKey, float value)
    {
        foreach (StatEntry stat in statCurrent)
        {
            if (stat.key == statKey)
            {
                stat.value += value;
                OnStatChange?.Invoke(statKey, stat.value);
            }
        }
        Debug.LogWarning("No stat " + statKey.ToString());
    }


    public void TakeDamage(int damage)
    {
        IncreaseStat(EnumName.Stat.Hp, -damage);
    }

    private void Awake()
    {
        SOStat statTemp  = Instantiate(statBase);
        statCurrent = new List<StatEntry> (statTemp.Stats);
    }


}
