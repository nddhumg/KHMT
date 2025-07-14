using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;

public class TimeWinCondition : IWinCondition
{
    protected float requiredTime;
    protected float startTime;
    protected float scaleTime;
    public TimeWinCondition(float requiredTime, float scaleTime = 1f/60) {
        this.requiredTime = requiredTime;
        startTime = Time.time;
        this.scaleTime = scaleTime;
    }

    public bool IsSatisfied()
    {
        return Time.time - startTime >= requiredTime / scaleTime;
    }
}
