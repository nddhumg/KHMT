using System.Collections;
using System.Collections.Generic;
using UI.Charector;
using UnityEngine;
namespace Systems.Inventory
{
    public class AppareItem : MonoBehaviour, IItemPickUp
    {
        public SOItem itemInfo { get; set; }

        public void PickUpAble()
        {
            InventoryManager.instance.AddItem(itemInfo);
            gameObject.SetActive(false);
        }

    }

}