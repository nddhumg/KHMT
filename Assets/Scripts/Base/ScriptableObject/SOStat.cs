using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnumName{
	public enum Stat{
		Hp,
		Speed,
		AttackRange,
		Damage
	}
}
[System.Serializable]
public class StatEntry
{
	public EnumName.Stat Key;
	public float Value;
}

[CreateAssetMenu(fileName = "StatData", menuName = "SO/Stat")]
public class SOStat : ScriptableObject
{
	[SerializeField] private List<StatEntry> stats = new List<StatEntry>();

	public float GetStatValue(EnumName.Stat statKey)
	{
		foreach (StatEntry stat in stats)
		{
			if (stat.Key == statKey)
				return stat.Value;
		}
		return 0f;
	}
}


