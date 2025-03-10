using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Systems.Inventory
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected CanvasGroup group;
        [SerializeField] protected RectTransform rect;

        [SerializeField] protected UIItem item;

        public Image Icon => icon;

        public void OnBeginDrag(PointerEventData eventData)
        {
            group.alpha = 0.6f;
            group.blocksRaycasts = false;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rect.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            UpdateUI(); 
        }

        public void UpdateUI() {
            group.alpha = 1f;
            group.blocksRaycasts = true;
            transform.SetParent(item.slot.transform);
            rect.anchoredPosition = Vector2.zero;
        }

    }

}