using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Inventory;

namespace Systems.SaveLoad
{
    [System.Serializable]
    public class GameData
    {
        public InventoryData inventory;
        public TimeData time;
        public ResourceData resource;
        public ShopData shop;

        public GameData()
        {
            inventory = new InventoryData();
            time = new TimeData();
            resource = new ResourceData();
            shop = new ShopData();
        }
    }
}
