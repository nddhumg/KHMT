using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Map/WinData/Time", fileName ="TimeWinDataMap")]
public class SOTimeWinData : ScriptableObject , IWinConditionData
{
    [SerializeField] protected string idMap;
    [SerializeField] protected float time;
    

    public IWinCondition GetCondition()
    {
        return new TimeWinCondition(time);
    }
}
