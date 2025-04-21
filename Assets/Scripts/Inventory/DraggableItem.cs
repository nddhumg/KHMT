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
        [SerializeField] protected RectTransform rect;

        [SerializeField] protected UIItem item;

        [SerializeField] private Color colorDrag;
        [SerializeField] private Color colorNormal;

        public Image Icon => icon;

        public void OnBeginDrag(PointerEventData eventData)
        {
            icon.color = colorDrag;
            icon.raycastTarget = false;
            transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionMouse.z = rect.position.z;
            rect.position = positionMouse;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            UpdateUI(); 
        }

        public void UpdateUI() {
            icon.color = colorNormal;
            icon.raycastTarget = true;
            transform.SetParent(item.slot.transform);
            rect.anchoredPosition = Vector2.zero;
        }

    }

}