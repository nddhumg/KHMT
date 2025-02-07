using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	[SerializeField] protected SOItemDrop itemsDrop;

	public virtual void Drop(Vector3 postionDrop,Quaternion rotationDrop){
		float ran = Random.value;
		float temp = 0;
		foreach (DropRate item in itemsDrop.DroppedItems) {
			temp += item.Rate;
			if (ran <= temp) {
				ItemPool.instance.GetFromPool (item.Item, postionDrop, rotationDrop);
			}
		}
	}
}
