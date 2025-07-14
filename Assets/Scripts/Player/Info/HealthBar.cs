using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Ndd.Stat;

public class HealthBar : SliderGameObject
{
    protected float hp, hpMax;
    protected IStat statBar;

    private void Start()
    {
        statBar = Player.instance.StatCurrent;
        statBar.OnStatUpdatedValue += UpdateSlider;
        hp = statBar.GetStatValue(StatName.Hp);
        hpMax = statBar.GetStatValue(StatName.HpMax);
    }
    protected void UpdateSlider(StatName stat, float value) {
        if (stat == StatName.Hp)
        {
            hp = value;
        }
        else if (stat == StatName.HpMax)
        {
            hpMax = value;
        }
        this.Value = hp / hpMax;
    }
}
