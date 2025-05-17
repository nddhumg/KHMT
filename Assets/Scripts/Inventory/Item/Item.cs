using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory
{
    [System.Serializable]
    public class Item : IItemData
    {
        [SerializeField] private string nameItem;
        [SerializeField] private int level;
        [NonSerialized] private IItemModel model;

        public Item(IItemModel model)
        {
            this.Init(model);
        }

        public void Init(IItemModel model)
        {
            this.model = model;
            this.nameItem = model.NameItem;
        }

        public void Equip()
        {
            InventoryManager.instance.EquipItem(this);
        }

        public void Dequip()
        {
            InventoryManager.instance.DequipItem(this);
        }

        public string Name => nameItem;

        public IItemModel Model => model;

        public int Level => level;
    }

}