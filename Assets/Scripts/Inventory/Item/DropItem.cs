using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	[SerializeField] protected List<SpawnRate> itemsDrop;

	public virtual void Drop(Vector3 postionDrop)
	{
		float ran = Random.value;
		float temp = 0;
		foreach (SpawnRate item in itemsDrop)
		{
			temp += item.Rate;
			if (ran <= temp)
			{
				ItemPool.instance.Spawn(item.Prefab, postionDrop, Quaternion.identity);
				return;
			}
		}
	}
}
