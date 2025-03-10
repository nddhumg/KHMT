
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using System;

[Serializable]
public class ResourceData : ISaveable
{
    public string ID { get; set; }

    public int coin;
    public int coinVip;
    public int energy;
}
