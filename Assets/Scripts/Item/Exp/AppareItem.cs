using System.Collections;
using System.Collections.Generic;
using UI.Charector;
using UnityEngine;

public class AppareItem : MonoBehaviour, IItemPickUp
{
    public SOItem itemInfo { get; set; }

    public void PickUpAble()
    {
        Inventory.instance.AddItem(itemInfo);
        gameObject.SetActive(false);
    }

}
