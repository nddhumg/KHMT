using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        protected RectTransform rect;
        public UIItem item;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        public virtual void Initialized(UIItem item)
        {
            this.item = item;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;
            UIItem item = eventData.pointerDrag.GetComponent<UIItem>();
            if (!CanItemSwap(item))
            {
                return;
            }
            DropItem(item);
        }

        public virtual void DropItem(UIItem item)
        {
            //item.ChangeSlot(this);
            ChangeItem(item);
        }

        public virtual void ChangeItem(UIItem itemNew)
        {
            UIItem oldItem = this.item;
            InventorySlot newSlot = itemNew.slot;
            
            this.item = itemNew;
            itemNew.slot = this;
            this.item.dragged.UpdateUI();

            if(oldItem == null)
            {
                Destroy(newSlot.gameObject);
            }
            newSlot.item = oldItem;
            if (oldItem != null)
            {
                oldItem.slot = newSlot;
                oldItem.dragged.UpdateUI();
            }
        }

        protected virtual bool CanItemSwap(UIItem item)
        {
            return true;
        }

    }
}

