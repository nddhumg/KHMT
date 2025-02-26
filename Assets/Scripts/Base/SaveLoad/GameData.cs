using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.SaveLoad
{
    [System.Serializable]
    public class GameData
    {
        public InventorySave inventory;

        public GameData()
        {
            inventory = new InventorySave();
        }
    }
}
