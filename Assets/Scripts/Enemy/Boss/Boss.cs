using Ndd.Stat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public abstract class Boss : MonoBehaviour , IReceiveDamage
{
    [SerializeField] protected SOStat stat;
    [SerializeField] protected string nameBoss;

    public IStat Stat => stat;
    public Action OnDead;
    public string NameBoss => nameBoss;


    protected virtual void Start()
    {
        stat = stat.Clone();
        stat.AddStatValue(StatName.Hp, stat.GetStatValue(StatName.HpMax));
        stat.OnStatUpdatedValue += CheckDead;
        UIHPBoss.instance.Init(this);
        OnDead += Dead;
    }
    public void TakeDamage(int damage)
    {
        stat.IncreaseStat(StatName.Hp, -damage);
    }


    protected void CheckDead(StatName statName, float value)
    {
        if (statName == StatName.Hp && value <= 0)
        {
            OnDead?.Invoke();
        }
    }

    
    protected virtual void Dead() { 
        Destroy(gameObject);
    }
}
