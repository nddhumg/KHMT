using EnumName;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestResourceRate : IChestRate
{
    private int valueIncrease;
    private ResourceName resourceName;

    public ChestResourceRate(ResourceName resource,int coin) 
    {
        this.valueIncrease = coin;
        this.resourceName = resource;
    }

    public void GenerateChestReward()
    {
        ResourceController.instance.IncreaseResource(resourceName, valueIncrease);
    }

    public Sprite GetIcon()
    {
        if (this.resourceName == ResourceName.Coin)
            return SystemChest.instance.IconCoin;
        else if (this.resourceName == ResourceName.CoinVip)
            return SystemChest.instance.IconCoinVip;
        else
            return null;
    }

    public string GetStringValue()
    {
        return "+ " + valueIncrease;
    }
}
