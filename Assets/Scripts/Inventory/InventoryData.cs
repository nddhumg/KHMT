using System;
using System.Collections.Generic;
using Systems.SaveLoad;
using EnumName;
namespace Systems.Inventory
{
    [Serializable]
    public class InventoryData : ISaveable
    {
        public List<Item> items;
        public Item[] equippedItem;

        public InventoryData()
        {
            items = new List<Item>();
            equippedItem = new Item[4];
        }
        public string ID { get; set; }

        public void CreateItem(IItemDataBase dataBase) {
            foreach (var item in equippedItem)
            {
                if (item.Name == string.Empty)
                    continue;
                item.Init(dataBase.GetModelByName(item.Name));
            }

            foreach (var item in items) {
                item.Init(dataBase.GetModelByName(item.Name));
            }
        }
    }
}