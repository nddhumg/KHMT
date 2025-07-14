using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalUpgradeData
{
    [SerializeField] protected List<GlobalUpgrade> globalUpgradeModel = new List<GlobalUpgrade>();

    public List<GlobalUpgrade> GlobalUpgradeModel
    {
        get => globalUpgradeModel;
    }
}
