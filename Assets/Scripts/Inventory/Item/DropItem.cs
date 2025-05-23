using Ndd.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	[SerializeField] protected List<GameObjectRate> itemsDrop;
	protected IRandomSelector<GameObject> itemDrop;

    protected virtual void Start()
    {
        itemDrop = new ChanceSelectorRandom<GameObject>();
		foreach (GameObjectRate objRate in itemsDrop) {
            itemDrop.AddItem(objRate.Object,objRate.Rate);
        }

	}

    public virtual void Drop(Vector3 postionDrop)
	{
		GameObject item = itemDrop.GetRandomItem();
        if (item == null)
        {
            return;
        }
        ItemPool.instance.Spawn(itemDrop.GetRandomItem(), postionDrop, Quaternion.identity);
	}
}
