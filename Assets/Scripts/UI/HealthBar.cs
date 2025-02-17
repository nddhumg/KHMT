using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider healthBarSlider;

    private void Start()
    {
        Player.instance.StatsManager.OnStatChange += UpdateSlider;
    }
    protected void UpdateSlider(EnumName.Stat stat, float value) {
        if (stat == EnumName.Stat.Hp)
        {
            float hpMax = Player.instance.StatsManager.GetStatValue(EnumName.Stat.HpMax);
            healthBarSlider.value = value / hpMax;
        }
        else if (stat == EnumName.Stat.HpMax) { 
            float hp = Player.instance.StatsManager.GetStatValue(EnumName.Stat.Hp);
            healthBarSlider.value = hp / value;
        }
    }
}
