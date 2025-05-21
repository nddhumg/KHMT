using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using EnumName;
using System;
namespace Systems.Inventory
{
    public class InventoryManager : PersistentSingleton<InventoryManager>
    {
        [SerializeField] InventoryData data;
        [SerializeField] private SOItemContainerModel containerModel;
        private IItemDataBase itemModelContainer;
        [SerializeField] private SOEquipmentStats soEquipmentStats;

        private IStat statbonus;
        public List<Item> ItemsCurrent => data.items;

        public Item EquippedWeapon => data.equippedItem[0];

        public Item[] EquippedItem => data.equippedItem;

        public SOEquipmentStats SOEquipmentStats => soEquipmentStats;

        public IStat StatsBonus { get => statbonus; set => statbonus = value; }

        public Action<Item> OnEquip;
        public Action<Item> OnDequip;
        public Action<Item, Item> OnSwapItem;


        protected override void Awake()
        {
            base.Awake();
            itemModelContainer = new InventoryModelContainer(containerModel.ItemCollection);
            statbonus = ScriptableObject.CreateInstance<SOStat>(); ;
        }

        protected virtual void Start()
        {
            data = SaveLoadSystem.DataService.Load<InventoryData>(gameObject) ?? data;
            CreateItem(itemModelContainer);
        }

        private void OnApplicationQuit()
        {
            SaveLoadSystem.DataService.Save<InventoryData>(ref data);
        }

        public void AddItem(Item item)
        {
            data.items.Add(item);
        }

        public void EquipItem(Item item)
        {
            EquipmentType typeItem = item.ModelData.Type;
            if (IsSlotEmty(typeItem))
            {
                data.items.Remove(item);
                data.equippedItem[(int)typeItem] = item;
            }
            else
            {
                Item itemCurrent = data.equippedItem[(int)typeItem];
                itemCurrent.Dequip();
                data.items.Remove(item);
                data.equippedItem[(int)typeItem] = item;
            }
            OnEquip?.Invoke(item);
        }

        public void DequipItem(Item item)
        {
            data.equippedItem[(int)item.ModelData.Type] = null;
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

        protected void CreateItem(IItemDataBase dataBase)
        {
            foreach (var item in data.equippedItem)
            {
                if (item.Name == string.Empty)
                    continue;
                item.Init(dataBase.GetModelByName(item.Name));
                statbonus.IncreaseStat(item.EquipmentStats.StatBonus, item.GetBonusStat());
            }

            foreach (var item in data.items)
            {
                item.Init(dataBase.GetModelByName(item.Name));
            }
        }
    }
}
