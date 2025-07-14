using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalUpgrade : IGlobalUpgrade
{
    [SerializeField] private string name;
    [SerializeField] private int levelCurrent = 0;
    [NonSerialized] private IGlobalUpgradeModel model;

    public GlobalUpgrade(IGlobalUpgradeModel model, int levelCurrent = 0)
    {
        this.model = model;
        this.name = model.Name;
        this.levelCurrent = levelCurrent;
    }

    public IGlobalUpgradeModel Model => model;

    public int LevelCurrent => levelCurrent;

    public string Name => name;

    public void Init(IGlobalUpgradeModel model)
    {
        this.model = model;
    }

    public void LevelUp()
    {
        this.levelCurrent++;
    }
}
