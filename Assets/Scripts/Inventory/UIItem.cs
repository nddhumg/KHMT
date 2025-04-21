using System.Collections;
using System.Collections.Generic;
using UI.Charector;
using UnityEngine;
using Systems.SaveLoad; 

namespace Systems.Inventory
{
    public class UIItem : MonoBehaviour
    {
        public SOItem info;
        public InventorySlot slot;
        public DraggableItem dragged;

        public string ID { get; set; }

        public void Initialized(InventorySlot slot, SOItem info)
        {
            this.slot = slot;
            this.info = info;
            dragged.Icon.sprite = info.icon;
        }
    }
}
