using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using EnumName;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.XR;
using System;
namespace Systems.Inventory
{
    public class InventoryManager : PersistentSingleton<InventoryManager>, IItemDataBase
    {
        [SerializeField] InventoryData data;
        [SerializeField] private List<SOItem> itemCollection;
        [SerializeField] private SOEquipmentStats soEquipmentStats;
        private Dictionary<string, SOItem> dictionaryItem;
        public List<Item> ItemsCurrent => data.items;

        public Item EquippedWeapon => data.equippedItem[0];

        public Item[] EquippedItem => data.equippedItem;

        public SOEquipmentStats SOEquipmentStats => soEquipmentStats;

        public Action<IItemData> OnEquip;
        public Action<IItemData> OnDequip;
        public Action<IItemData, IItemData> OnSwapItem;
        public Action<EnumName.Stat, float> onChangeStat;


        protected override void Awake()
        {
            base.Awake();
            CreateItemController();
        }

        protected virtual void Start()
        {
            data = SaveLoadSystem.DataService.Load<InventoryData>(gameObject) ?? data;
            data.CreateItem(this);
        }

        private void OnApplicationQuit()
        {
            SaveLoadSystem.DataService.Save<InventoryData>(ref data);
        }

        public void AddItem(Item item)
        {
            data.items.Add(item);
        }


        public IItemModel GetModelByName(string name)
        {
            if (!dictionaryItem.ContainsKey(name))
            {
                Debug.LogWarning("The model " + name + " is not in the list.");
                return null;
            }
            return dictionaryItem[name];
        }

        public void EquipItem(Item item)
        {
            EquipmentType typeItem = item.Model.Type;
            if (IsSlotEmty(typeItem))
            {
                data.items.Remove(item);
                data.equippedItem[(int)typeItem] = item;
                IEquipmentStats stats = soEquipmentStats.GetEquipmentStats(item.Model.Type);
                onChangeStat?.Invoke(stats.StatBonus, stats.GetBonus(0));
                OnEquip?.Invoke(item);
            }
            else
            {
                data.items.Remove(item);
                Item itemCurrent = data.equippedItem[(int)typeItem];
                data.equippedItem[(int)typeItem] = item;
                IEquipmentStats stats = soEquipmentStats.GetEquipmentStats(item.Model.Type);
                onChangeStat?.Invoke(stats.StatBonus, stats.GetBonus(0));
                data.items.Add(itemCurrent);
                onChangeStat?.Invoke(stats.StatBonus, -1 * stats.GetBonus(0));
                OnSwapItem?.Invoke(item, itemCurrent);
            }
        }

        public void DequipItem(Item item)
        {
            data.equippedItem[(int)item.Model.Type] = null;
            data.items.Add(item);
            OnDequip?.Invoke(item);
        }
        public void ClearSlotEmty()
        {
            data.items.RemoveAll(item => item == null || item.Name == string.Empty);
        }

        public bool IsSlotEmty(EquipmentType type)
        {
            try
            {
                return data.equippedItem[(int)type].Name == string.Empty || data.equippedItem[(int)type].Name == null;
            }
            catch { return true; }
        }

        private void CreateItemController()
        {
            dictionaryItem = new();
            foreach (SOItem model in itemCollection)
            {
                try
                {
                    dictionaryItem.Add(model.NameItem, model);
                }
                catch
                {
                    Debug.Log(model.NameItem);
                }
            }
        }
    }
}
