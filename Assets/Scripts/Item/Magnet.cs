using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour, IItemPickUp
{
    public static Action pickUpMagnet;
    public void PickUpAble()
    {
        pickUpMagnet?.Invoke();
        gameObject.SetActive(false);
    }
}
