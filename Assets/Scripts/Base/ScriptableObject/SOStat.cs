using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnumName{
	public enum Stat{
		Hp,
		Speed,
		AttackRange,
		Damage,
		AttackRate,
	}
}
[System.Serializable]
public class StatEntry
{
	public EnumName.Stat key;
	public float value;
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


