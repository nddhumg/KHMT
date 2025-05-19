using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICooldown 
{
    public float Cooldown { get; set; }

    public float Timer { get; }

    void UpdateCooldown(float elapsedTime);

    void ResetCooldown();

}
