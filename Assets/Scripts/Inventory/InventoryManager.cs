using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using Unity.Collections;
namespace Systems.Inventory
{
    public class InventoryManager : PersistentSingleton<InventoryManager>
    {
        [SerializeField] SOStat statPlayer;
        [SerializeField] InventoryData data ;

        public List<SOItem> ItemsCurrent => data.items;

        public SOItem EquippedWeapon => data.equippedItem[0];

        public SOItem[] EquippedItem => data.equippedItem;

        protected override void Awake()
        {
            base.Awake();
            data = SaveLoadSystem.DataService.Load<InventoryData>() ?? data;
        }
        private void OnApplicationQuit()
        {
            SaveLoadSystem.DataService.Save<InventoryData>(ref data);
        }
        public void AddItem(SOItem item)
        {
            data.items.Add(item);
        }

        public void EquipItem(SOItem item)
        {
            data.items.Remove(item);
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
            if (item == null)
                return;
            data.items.Add(item);
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
        public void ClearSlotEmty()
        {
            data.items.RemoveAll(item => item == null);
        }
    }
}
