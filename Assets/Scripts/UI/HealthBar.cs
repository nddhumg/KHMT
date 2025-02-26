using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider healthBarSlider;
    protected float hp, hpMax;


    private void Start()
    {
        Player.instance.StatsManager.StatCurrent.OnChangeStat += UpdateSlider;
        hp = Player.instance.StatsManager.StatCurrent.GetStatValue(EnumName.Stat.Hp);
        hpMax = Player.instance.StatsManager.StatCurrent.GetStatValue(EnumName.Stat.HpMax);
    }
    protected void UpdateSlider(EnumName.Stat stat, float value) {
        if (stat == EnumName.Stat.Hp)
        {
            hp = value;
        }
        else if (stat == EnumName.Stat.HpMax)
        {
            hpMax = value;
        }
        healthBarSlider.value = hp / hpMax;
    }
}
