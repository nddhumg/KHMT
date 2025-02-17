using System.Collections;
using System.Collections.Generic;
using EnumName;
using UnityEngine;
namespace EnumName{
	public enum Stat{
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
public class SOStat : ScriptableObject
{
	[SerializeField] private List<StatEntry> stats = new List<StatEntry>();

	public List<StatEntry> Stats{
		get{
			return stats;
		}
	}

	public float GetStatValue(EnumName.Stat statKey)
	{
		foreach (StatEntry stat in stats)
		{
			if (stat.key == statKey)
				return stat.value;
		}
		return 0f;
	}
}


