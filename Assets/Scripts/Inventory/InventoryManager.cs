using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using EnumName;
namespace Systems.Inventory
{
    public class InventoryManager : PersistentSingleton<InventoryManager>
    {
        [SerializeField] SOStat statPlayer;
        [SerializeField] InventoryData data;
        [SerializeField] private List<SOItem> itemCollection;
        private Dictionary<EnumName.Item, HashSet<SOItem>> dictionaryItem = new();
        public List<Item> ItemsCurrent => data.items;

        public Item EquippedWeapon => data.equippedItem[0];

        public Item[] EquippedItem => data.equippedItem;

        protected override void Awake()
        {
            base.Awake();
            CreateItemController();
            //data = SaveLoadSystem.DataService.Load<InventoryData>() ?? data;
        }

        protected virtual void Start()
        {
            data = SaveLoadSystem.DataService.Load<InventoryData>(gameObject) ?? data;
        }

        private void OnApplicationQuit()
        {
            SaveLoadSystem.DataService.Save<InventoryData>(ref data);
        }

        public void AddItem(Item item)
        {
            data.items.Add(item);
        }

        public SOItem GetSOItem(Item name)
        {
            if (name == Item.None)
                return null;
            foreach (SOItem item in dictionaryItem[name])
            {
                if (item.nameItem == name)
                    return item;
            }
            Debug.Log("Item " + name + " is not in the dictionaryItem yet");
            return null;
        }

        public void EquipItem(Item item)
        {
            data.items.Remove(item);
            SOItem soItem = GetSOItem(item);
            foreach (StatEntry bonus in soItem.bonusStat)
            {
                statPlayer.IncreaseStat(bonus.key, bonus.value);
            }
            switch (soItem.equipmentType)
            {
                case EquipmentType.Weapon:
                    data.equippedItem[0] = item;
                    break;
                case EquipmentType.Armor:
                    data.equippedItem[1] = item;
                    break;
            }
        }

        public void DequipItem(Item item)
        {
            if (item == Item.None)
                return;
            data.items.Add(item);
            SOItem soItem = GetSOItem(item);
            foreach (StatEntry bonus in soItem.bonusStat)
            {
                statPlayer.IncreaseStat(bonus.key, bonus.value * -1);
            }
            switch (soItem.equipmentType)
            {
                case EquipmentType.Weapon:
                    data.equippedItem[0] = Item.None;
                    break;
                case EquipmentType.Armor:
                    data.equippedItem[1] = Item.None;
                    break;
            }
        }
        public void ClearSlotEmty()
        {
            data.items.RemoveAll(item => item == Item.None);
        }

        private void CreateItemController()
        {
            foreach (SOItem so in itemCollection)
            {
                if (dictionaryItem.ContainsKey(so.nameItem))
                    continue;
                dictionaryItem.Add(so.nameItem, new HashSet<SOItem>());
                dictionaryItem[so.nameItem].Add(so);
            }
        }
    }
}
