using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Charector
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        protected RectTransform rect;
         protected DraggableItem draggableItem;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        public virtual void Initialized(DraggableItem drag) { 
            this.draggableItem = drag;
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            DraggableItem itemDraggable = eventData.pointerDrag.GetComponent<DraggableItem>();
            if (itemDraggable == null || !CanItemSwap(itemDraggable))
                return;
            ItemSwap(itemDraggable);
        }

        public virtual void ItemSwap(DraggableItem draggableNew)
        {
            if (IsSlotEmpty())
            {
                draggableNew.InventorySlot.draggableItem = null;
            }
            else {
                this.draggableItem.GoToSlot(draggableNew.InventorySlot);

            }
            this.draggableItem = draggableNew;
            this.draggableItem.GoToSlot(this);
           
        }

        public virtual bool CanItemSwap(DraggableItem draggable) {
            return draggableItem != draggable ;
        }

        protected bool IsSlotEmpty(){
            return draggableItem == null;
        }
    }
}
