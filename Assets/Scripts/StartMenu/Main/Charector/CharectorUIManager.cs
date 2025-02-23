using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Charector
{
    public class CharectorUIManager : MonoBehaviour
    {
        [SerializeField] protected InventorySlot[] charectorSlot;
        [SerializeField] protected Transform inventoryUI;
        [SerializeField] protected GameObject prefabItem;
        [SerializeField] protected GameObject prefabSlot;


        private void Start()
        {
            CreateInventory();
        }
        protected void CreateInventory() {
            InventorySlot slot;
            DraggableItem drag;
            foreach (SOItem item in Inventory.instance.ItemsCurrent)
            {
                slot = Instantiate(prefabSlot, inventoryUI).GetComponent<InventorySlot>();
                drag = Instantiate(prefabItem, slot.transform).GetComponent<DraggableItem>();
                slot.Initialized(drag);
                drag.Initialized(item,slot);
            }
        }
    }
}
