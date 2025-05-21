using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Systems.Inventory
{
    [System.Serializable]
    public class Item : IItemData, IItemLevel , IItemBonusStat
    {
        [SerializeField] private string nameItem;
        [SerializeField] private int level;
        [NonSerialized] private IItemModel model;

        public IItemLevel LevelData => this;
        public int Level => level;

        public string Name => nameItem;

        public IItemModel ModelData => model;

        public Action<int> OnLevelUp { get ; set ; }

        public IEquipmentStats EquipmentStats { get; private set; }

        public IItemBonusStat BonusStatData => this;

        public Item(IItemModel model)
        {
            this.Init(model);
        }

        public void Init(IItemModel model)
        {
            this.model = model;
            this.nameItem = model.NameItem;
            EquipmentStats = InventoryManager.instance.SOEquipmentStats.GetEquipmentStats(this.model.Type);
        }

        public void LevelUp()
        {
            level++;
            OnLevelUp?.Invoke(level);
        }

        public void LevelUp(int level)
        {
            level += level;
            OnLevelUp?.Invoke(level);
        }

        public void Equip()
        {
            InventoryManager.instance.EquipItem(this);
            InventoryManager.instance.StatsBonus.IncreaseStat(EquipmentStats.StatBonus, GetBonusStat());

        }

        public void Dequip()
        {
            InventoryManager.instance.DequipItem(this);
            InventoryManager.instance.StatsBonus.IncreaseStat(EquipmentStats.StatBonus, -GetBonusStat());
        }

        public float GetBonusStat( ) {
            float bonus = 0;
            bonus += EquipmentStats.GetBonus(0);
            bonus += EquipmentStats.GetBonusLevelUp(0) * level;
            return bonus;
        }

    }

}