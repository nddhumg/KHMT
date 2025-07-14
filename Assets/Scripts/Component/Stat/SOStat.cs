using System;
using System.Collections;
using System.Collections.Generic;
using EnumName;
using UnityEngine;
namespace Ndd.Stat
{
    [System.Serializable]
    public class StatEntry
    {
        public StatName key;
        public float value;

        public StatEntry(StatName key, float value)
        {
            this.key = key;
            this.value = value;
        }
    }

    [CreateAssetMenu(fileName = "StatData", menuName = "SO/Stat")]
    public class SOStat : ScriptableObject, IStat
    {
        [SerializeField] private List<StatEntry> stats = new List<StatEntry>();

        public Action<StatName, float> OnStatUpdatedValue { get; set; }
        public List<StatEntry> Stats => stats;

        public Action<StatName, float> OnStatChangedValue { get; set; }

        public static SOStat operator +(SOStat a, SOStat b)
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
        public float GetStatValue(StatName statKey)
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

        public void SetStatValue(StatName statKey, float value)
        {
            float valueOld;
            try
            {
                StatEntry statEntry = GetStatEntry(statKey);
                valueOld = statEntry.value;
                statEntry.value = value;
                OnStatChangedValue?.Invoke(statKey, valueOld - value);
            }
            catch
            {
                stats.Add(new StatEntry(statKey, value));
                Debug.LogWarning("Create stat :" + statKey.ToString());
                OnStatChangedValue?.Invoke(statKey, value);
            }
            OnStatUpdatedValue?.Invoke(statKey, GetStatValue(statKey));
        }

        public void IncreaseStat(StatName statKey, float value, bool isDebug = true)
        {
            try
            {
                StatEntry statEntry = GetStatEntry(statKey);
                statEntry.value += value;
                OnStatChangedValue?.Invoke(statKey, value);
            }
            catch
            {
                stats.Add(new StatEntry(statKey, value));
                if (isDebug)
                {
                    Debug.LogWarning("Create stat :" + statKey.ToString());
                }
                OnStatChangedValue?.Invoke(statKey, value);
            }
            OnStatUpdatedValue?.Invoke(statKey, GetStatValue(statKey));
        }

        public void PercentageIncreaseStat(StatName statKey, float value)
        {
            try
            {
                StatEntry entry = GetStatEntry(statKey);
                float valueIncrease = entry.value * value / 100;
                entry.value += valueIncrease;
                OnStatChangedValue?.Invoke(statKey, valueIncrease);
                OnStatUpdatedValue?.Invoke(statKey, GetStatValue(statKey));
            }
            catch
            {
                Debug.LogWarning("No stat " + statKey.ToString());
            }

        }

        public StatEntry GetStatEntry(StatName statKey)
        {
            foreach (StatEntry stat in stats)
            {
                if (stat.key == statKey)
                    return stat;
            }

            return null;
        }
        public void AddStatValue(StatName statKey, float value)
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
            foreach (StatEntry stat in stats.Stats)
            {
                IncreaseStat(stat.key, stat.value);
            }
        }

    }


}