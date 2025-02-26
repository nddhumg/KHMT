using System.Collections;
using System.Collections.Generic;
using EnumName;
using UnityEngine;


public abstract class SOUpgrade : ScriptableObject {
    [SerializeField] protected Sprite icon;

    public Sprite Icon => icon; 


    public abstract void ApplyUpgrade();
    public abstract string GetDescription();
}
