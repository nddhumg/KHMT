using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropRate{
	[SerializeField] private float rate;
	[SerializeField] private GameObject item;

	public float Rate{
		get{ 
			return rate;
		}
	}

	public GameObject Item{
		get{ 
			return item;
		}
	}

}
[CreateAssetMenu(fileName = "DropItem", menuName = "SO/Item/Drop")]
public class SOItemDrop : ScriptableObject {
	[SerializeField] protected List<DropRate> droppedItems;

	public  List<DropRate> DroppedItems{
		get{ 
			return droppedItems;
		}
	}
}
