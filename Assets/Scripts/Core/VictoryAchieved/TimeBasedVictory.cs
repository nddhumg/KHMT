using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedVictory : VictoryAchieved
{
    [SerializeField] protected float winTimeLimit;

    protected override bool CanVictory()
    {
        return Time.timeSinceLevelLoad > winTimeLimit * 60;
    }
}
