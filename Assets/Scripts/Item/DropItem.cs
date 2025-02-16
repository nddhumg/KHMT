using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
	[SerializeField] protected SOSpawnRate itemsDrop;

	public virtual void Drop(Vector3 postionDrop,Quaternion rotationDrop){
		float ran = Random.value;
		float temp = 0;
		foreach (SpawnRate item in itemsDrop.SpawnRateList) {
			temp += item.Rate;
			if (ran <= temp) {
				ItemPool.instance.GetFromPool (item.Prefab, postionDrop, rotationDrop);
			}
		}
	}
}
