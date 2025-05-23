using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : SpawnPoolGameObject<ItemPool>
{
    [SerializeField] private GameObject itemsExp;
    public void SpawnExp(Vector3 pos)
    {
        this.Spawn(itemsExp, pos, Quaternion.identity);
    }
}
