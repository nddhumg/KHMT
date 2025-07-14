using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;


public class HealthPoint : MonoBehaviour ,IItemPickUp
{
    [SerializeField] protected int hpRecovery;
    [SerializeField] protected bool isPercentage;
    protected IStat statPlayer;

    void Start() { 
        statPlayer = Player.instance.StatCurrent;
    }
    public void PickUpAble()
    {
        if (!isPercentage)
        {
            statPlayer.IncreaseStat(StatName.Hp, hpRecovery);
        }
        else
        {
            statPlayer.PercentageIncreaseStat(StatName.Hp, hpRecovery);
        }
        Player.instance.ActiveEffectHealing();
        gameObject.SetActive(false);
    }

}
