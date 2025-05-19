using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownChecker : CooldownTimer ,ICooldownChecker
{
    private bool isTimeout;

    public bool IsTimeout => isTimeout;

    public CooldownChecker(float cooldown = 1f, float timeScale = 1) : base(cooldown, timeScale)
    {
    }


    protected override void TriggerTimeout()
    {
        isTimeout = true;
    }

    protected override bool IsCooldownActive()
    {
        return base.IsCooldownActive() || !isTimeout;
    }
}
