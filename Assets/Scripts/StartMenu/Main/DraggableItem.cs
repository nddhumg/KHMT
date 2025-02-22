using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Charector
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected Canvas canvas;
        [SerializeField] protected CanvasGroup group;
        protected RectTransform rect;
        protected InventorySlot inventorySlot;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            inventorySlot = transform.parent.GetComponent<InventorySlot>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            group.alpha = 0.6f;
            group.blocksRaycasts = false;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            group.alpha = 1f;
            group.blocksRaycasts = true;
            transform.SetParent(inventorySlot.transform);
            rect.anchoredPosition = Vector2.zero;
        }

        public void SetItem(RectTransform rectParent, Transform parent, InventorySlot slot)
        {
            inventorySlot.SetIsSlotOccupied(false);
            transform.SetParent(parent);
            rect.anchoredPosition = Vector2.zero;
            this.inventorySlot = slot;
            slot.SetIsSlotOccupied(true);
        }

    }

}