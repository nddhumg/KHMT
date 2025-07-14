using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobalUpgrade
{
    public IGlobalUpgradeModel Model { get; }
    public int LevelCurrent { get; }

    public string Name { get; }

    public void LevelUp();
}
