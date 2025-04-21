using EnumName;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestResourceRate : ChestRate
{
    private int valueIncrease;
    private ResourceName resourceName;

    public ChestResourceRate(ResourceName resource,int coin,float rate) : base(rate)
    {
        this.valueIncrease = coin;
        this.resourceName = resource;
    }

    public override void GenerateChestReward()
    {
        ResourceController.instance.IncreaseResource(resourceName, valueIncrease);
    }

    public override Sprite GetIcon()
    {
        if (this.resourceName == ResourceName.Coin)
            return SystemChest.instance.IconCoin;
        else if (this.resourceName == ResourceName.CoinVip)
            return SystemChest.instance.IconCoinVip;
        else
            return null;
    }

    public override string GetStringValue()
    {
        return "+ " + valueIncrease;
    }
}
