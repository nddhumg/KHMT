using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatsManager : MonoBehaviour {
	protected List<StatEntry> stats = new List<StatEntry>();
	[SerializeField] protected SOStat statSO;
	public Action<EnumName.Stat,float> ChangeStat;

	void OnValidate(){
		stats = statSO?.Stats;
	}

	public float GetStatValue(EnumName.Stat statKey)
	{
		foreach (StatEntry stat in stats)
		{
			if (stat.key == statKey)
				return stat.value;
		}
		return -1f;
	}

	public void SetStatValue(EnumName.Stat statChange,float value)
	{
		if (value < 0)
			return;
		ChangeStat?.Invoke (statChange, value);
		stats [GetIndexStat (statChange)].value = value;
	}

	public void IncreaseStat(EnumName.Stat statChange,float value){
		if (value < 0)
			return;
		int indexStatChange = GetIndexStat (statChange);
		stats [indexStatChange].value += value;
		ChangeStat?.Invoke (statChange, stats [indexStatChange].value);
	}

	protected int GetIndexStat(EnumName.Stat statKey){
		for (int index = 0; index < stats.Count; index++) {
			if (stats [index].key == statKey)
				return index;
		}
		return -1;
	}
}
