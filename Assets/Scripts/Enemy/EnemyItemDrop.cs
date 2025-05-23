using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : DropItem
{
    public override void Drop(Vector3 postionDrop)
    {
        base.Drop(postionDrop);
        //ItemPool.instance.SpawnExp(postionDrop);
    }
}
