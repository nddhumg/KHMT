using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChestRate 
{
    //private float rate;
    public ChestRate() {
        //this.rate = rate;
    }

    //public float Rate { get => rate; set => rate = value; }

    public abstract void GenerateChestReward();
    public abstract Sprite GetIcon();
    public abstract string GetStringValue();

}
