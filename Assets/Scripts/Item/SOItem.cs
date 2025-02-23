using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BonusStatItem {
    public EnumName.Stat stat;
    public float boost;
}

[CreateAssetMenu(menuName = "SO/Item/Appare")]
public class SOItem : ScriptableObject
{
    public Sprite icon;
    public EnumName.EquipmentType equipmentType;
    public List<BonusStatItem> bonusStat;

    public void CreateItemInGame(Vector3 position,Quaternion rotation){
        AppareItem item =  ItemPool.instance.SpawnItemAppare(position, rotation).GetComponent<AppareItem>();
        item.itemInfo = this;
    }

    public void Equip() { 
        
    }

    public void Dequip() { 
        
    }

}
