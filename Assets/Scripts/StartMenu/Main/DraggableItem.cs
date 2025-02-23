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
        //[SerializeField] protected Canvas canvas;
        [SerializeField] protected CanvasGroup group;
        protected RectTransform rect;
        [SerializeField]protected SOItem itemInfo;
        [SerializeField]protected InventorySlot inventorySlot;
        protected bool isSwapItem = false;

        public SOItem ItemInfo { get => itemInfo; set => itemInfo= value; }
        public InventorySlot InventorySlot { get => inventorySlot; set => inventorySlot = value; }

        public void Initialized(SOItem item, InventorySlot slot) {
            this.InventorySlot = slot;
            itemInfo = item;
            icon.sprite = item.icon;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            group.alpha = 0.6f;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            //rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
            rect.anchoredPosition += eventData.delta;
            group.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            group.alpha = 1f;
            group.blocksRaycasts = true;
            if (isSwapItem) { 
                isSwapItem = false;
                return;
            }
            transform.SetParent(inventorySlot.transform);
            rect.anchoredPosition = Vector2.zero;
        }

        public void GoToSlot(InventorySlot slot)
        {
            transform.SetParent(slot.transform);
            rect.anchoredPosition = Vector2.zero;
            this.inventorySlot = slot;
            isSwapItem = true;
        }

        void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

    }

}