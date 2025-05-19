using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCooldownTimer : CooldownTimer, ICoolDownAuto
{
    public Action OnTimeout;

    public AutoCooldownTimer(float cooldown = 1f, float timeScale = 1) : base(cooldown,timeScale)
    {
    }

    public void AddTimeoutListener(Action action)
    {
        OnTimeout += action;
    }

    public void ClearTimeoutListeners()
    {
        OnTimeout = null;
    }

    public void RemoveTimeoutListener(Action action)
    {
        OnTimeout -= action;
    }

    protected override void TriggerTimeout()
    {
        base.TriggerTimeout();
        OnTimeout?.Invoke();
    }
}

