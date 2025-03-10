using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
namespace Systems.Inventory
{
    [Serializable]
    public class InventoryData : ISaveable
    {
        public List<SOItem> items;
        public SOItem[] equippedItem;

        public InventoryData()
        {
            items = new List<SOItem>();
            equippedItem = new SOItem[4];
        }
        public string ID { get; set; }
    }
}