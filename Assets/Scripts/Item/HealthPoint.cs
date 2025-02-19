using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour ,IItemPickUp
{
    [SerializeField] protected int hpRecovery;
    [SerializeField] protected bool isPercentage;
    public void PickUpAble()
    {
        if(!isPercentage)
            Player.instance.StatsManager.IncreaseStat(EnumName.Stat.Hp, hpRecovery);
        else
        {
            Player.instance.StatsManager.PercentageIncreaseStat(EnumName.Stat.Hp, hpRecovery);
        }
        gameObject.SetActive(false);
    }

}
