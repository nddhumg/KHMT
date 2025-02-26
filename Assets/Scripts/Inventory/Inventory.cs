using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using System.Runtime.InteropServices;

[Serializable]
public class InventorySave : ISaveable
{
   [SerializeField,ReadOnly]private string id; 
   public List<SOItem> items;
   public SOItem[] equippedItem ;

    public InventorySave() {
        items = new List<SOItem>();
        equippedItem = new SOItem[4];
    }
   public string ID { get => id; set => id = value; }
}
public class Inventory : PersistentSingleton<Inventory> , IBind<InventorySave>
{
    [SerializeField] SOStat statPlayer;
    [SerializeField] InventorySave data ;
    [SerializeField,ReadOnly] string id;
    public List<SOItem> ItemsCurrent => data.items;

    public SOItem EquippedWeapon => data.equippedItem[0];

    public string ID { get => id; set => id = value; }

    public void AddItem(SOItem item)
    {
        data.items.Add(item);
    }

    public void EquipItem(SOItem item)
    {
        foreach (StatEntry bonus in item.bonusStat)
        {
            statPlayer.IncreaseStat(bonus.key, bonus.value);
        }
        switch (item.equipmentType)
        {
            case EnumName.EquipmentType.Weapon:
                data.equippedItem[0] = item;
                break;
            case EnumName.EquipmentType.Armor:
                data.equippedItem[1] = item;
                break;
        }
    }

    public void DequipItem(SOItem item)
    {
        foreach (StatEntry bonus in item.bonusStat)
        {
            statPlayer.IncreaseStat(bonus.key, bonus.value * -1);
        }
        switch (item.equipmentType)
        {
            case EnumName.EquipmentType.Weapon:
                data.equippedItem[0] = null;
                break;
            case EnumName.EquipmentType.Armor:
                data.equippedItem[1] = null;
                break;
        }
    }

    public void Bind(InventorySave dataSave)
    {
        this.data = dataSave;
        this.data.ID = ID;
        ClearSlotEmty();
    }

    public void ClearSlotEmty() {
        data.items.RemoveAll(item => item == null);
    }
}
