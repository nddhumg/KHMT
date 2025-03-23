using System;
using System.Collections;
using System.Collections.Generic;
using Systems.SaveLoad;
using UnityEngine;

[Serializable]
public class ShopData : ISaveable
{
    public string lastFreeCoinClaimDate;
    public string lastFreeCoinVipClaimDate;

    public string ID { get; set; }
}
