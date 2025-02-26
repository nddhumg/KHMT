using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : SpawnPool<ItemPool> {
	[SerializeField] protected GameObject itemAppare;

	public GameObject SpawnItemAppare(Vector3 positionSpawn, Quaternion rotationSpawn) {
		return Spawn(itemAppare, positionSpawn, rotationSpawn);
	}
}
