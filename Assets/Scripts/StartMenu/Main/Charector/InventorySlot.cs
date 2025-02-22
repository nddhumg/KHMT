using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Charector
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        protected bool isSlotOccupied;
        protected RectTransform rect;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                SetItem(eventData.pointerDrag);
            }
        }

        public void SetIsSlotOccupied(bool isSlotOccupied)
        {
            this.isSlotOccupied = isSlotOccupied;
        }

        protected virtual void SetItem(GameObject gameObjItem)
        {
            DraggableItem item = gameObjItem.GetComponent<DraggableItem>();
            item?.SetItem(rect, transform, this);
        }
    }
}
