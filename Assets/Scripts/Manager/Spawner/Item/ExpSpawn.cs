using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Random;
using Ndd.Cooldown;

public class ExpSpawn
{
    IRandomSelector<GameObject> expItemSelector;
    ICoolDownAuto expTimerChance;
    SOExpSpawn spawnData;
    int indexRate = 0;

    public ExpSpawn(IRandomSelector<GameObject> expItemSelector, SOExpSpawn spawnData)
    {
        this.expItemSelector = expItemSelector;
        this.spawnData = spawnData;
        for (int i = 0; i < spawnData.ExpPrefabs.Count; i++)
        {
            expItemSelector.AddItem(spawnData.ExpPrefabs[i], spawnData.ExpRates[indexRate].Rate[i]);
        }
        expTimerChance = new AutoCooldownTimer(spawnData.ExpRates[0].TimeChange, 1f/60);
        expTimerChance.AddTimeoutListener(NextExpRate);
    }

    public void Update()
    {
        expTimerChance.UpdateCooldown(Time.deltaTime);
    }

    public GameObject GetExpSpawn()
    {
        return expItemSelector.GetRandomItem();
    }

    protected void NextExpRate()
    {
        indexRate++;
        if (indexRate >= spawnData.ExpRates.Count)
        {
            expTimerChance.ClearTimeoutListeners();
            return;
        }
        for (int i = 0; i < spawnData.ExpPrefabs.Count; i++)
        {
            expItemSelector.SetRateItem(i, spawnData.ExpRates[indexRate].Rate[i]);
        }
        expTimerChance.Cooldown = spawnData.ExpRates[indexRate].TimeChange;
    }

}
