using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobalUpgradeModel 
{
    public Sprite Icon { get; }
    public IGlobalUpgradeLevel[] GlobalUpgradeLevels { get; }
    public string Name { get; }
    public int LevelMax { get; }
}

public interface IGlobalUpgradeLevel { 
    public string Description { get; }
    public uint Cost { get; }
}
