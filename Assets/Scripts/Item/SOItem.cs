using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item/Appare")]
public class SOItem : ScriptableObject
{
    public EnumName.AppareItem nameItem;
    public Sprite icon;
    public EnumName.EquipmentType equipmentType;
    public List<StatEntry> bonusStat;

    public void CreateItemInGame(Vector3 position,Quaternion rotation){
        AppareItem item =  ItemPool.instance.SpawnItemAppare(position, rotation).GetComponent<AppareItem>();
        item.itemInfo = this;
    }

    public void Equip() { 
        Inventory.instance.EquipItem(this);
    }

    public void Dequip() { 
        Inventory.instance.DequipItem(this);
    }

}
