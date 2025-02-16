using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoolDownTimer
{
    private float timer = 0;
    private float coolDown;
    private bool isAutoResetCoolDown;
    public bool IsCoolDownOver { get; private set; }
    public Action OnCoolDownEnd;

    public CoolDownTimer(float coolDown, bool isAutoResetCoolDown = true)
    {
        this.coolDown = coolDown;
        this.isAutoResetCoolDown = isAutoResetCoolDown;
        if (isAutoResetCoolDown) {
            OnCoolDownEnd += ResetCoolDown;
        }
    }

    public void CountTime(float elapsedTime) {
        if (IsCoolDownOver) return;

        timer += elapsedTime;
        if (timer >= coolDown) { 
            IsCoolDownOver = true;
            OnCoolDownEnd?.Invoke();
        }
    }

    public void ResetCoolDown() { 
        IsCoolDownOver=false;
        timer = 0;
    }

    public void SetAutoResetCoolDown(bool isAuto) {
        if (isAutoResetCoolDown == isAuto)
            return;
        if (isAuto) {
            OnCoolDownEnd += ResetCoolDown;
        }
        else
        {
            OnCoolDownEnd -= ResetCoolDown;
        }
    }
}
