using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimePool : DestroyAfterTime
{
    [SerializeField] private GameObject obj;
    protected override void DestroyObject()
    {
        obj.gameObject.SetActive(false);
    }
}
