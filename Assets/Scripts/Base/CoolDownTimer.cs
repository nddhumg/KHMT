using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoolDownTimer
{
    private float timer =0;
    private float coolDowl;
    public bool IsCoolDownOver { get; private set; }
    public Action OnCoolDownEnd;

    public CoolDownTimer(float coolDown, bool isAutoResetCoolDown = true)
    {
        this.coolDowl = coolDown;
        if (isAutoResetCoolDown) {
            OnCoolDownEnd += ResetCoolDown;
        }
    }

    public void CountTime(float elapsedTime) {
        if (IsCoolDownOver) return;

        timer += elapsedTime;
        if (timer >= coolDowl) { 
            IsCoolDownOver = true;
            OnCoolDownEnd?.Invoke();
        }
    }

    public void ResetCoolDown() { 
        IsCoolDownOver=false;
        timer = 0;
    }


}
