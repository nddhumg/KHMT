using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IItemPickUp
{
    protected int coin;
    protected int coinMax;
    
    public void PickUpAble()
    {
        SystemChest.instance.CreateChest();
        gameObject.SetActive(false);
    }

}
