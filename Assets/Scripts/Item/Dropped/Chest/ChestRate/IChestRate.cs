using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IChestRate 
{
    public abstract void GenerateChestReward();
    public abstract Sprite GetIcon();
    public abstract string GetStringValue();

}
