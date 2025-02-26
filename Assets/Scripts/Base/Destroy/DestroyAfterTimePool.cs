using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimePool : DestroyAfterTime
{
    protected override void DestroyObject()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
