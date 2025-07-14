using System.Collections;
using System.Collections.Generic;
using EnumName;
using UnityEngine;


public abstract class SOUpgrade : ScriptableObject {
    [SerializeField] protected Sprite icon;
    [SerializeField] protected bool isSkill;

    public Sprite Icon => icon; 


    public abstract void ApplyUpgrade(Player player);
    public abstract string GetDescription(Player player);
}
