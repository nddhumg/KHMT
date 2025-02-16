using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnRate{
	[SerializeField] private float rate;
	[SerializeField] private GameObject prefab;

	public float Rate{
		get{ 
			return rate;
		}
	}

	public GameObject Prefab{
		get{ 
			return prefab;
		}
	}

}
[CreateAssetMenu(fileName = "SpawnRate", menuName = "SO/SpawnRate")]
public class SOSpawnRate : ScriptableObject {
	[SerializeField] protected List<SpawnRate> spawnRateList;

	public  List<SpawnRate> SpawnRateList{
		get{ 
			return spawnRateList;
		}
	}
}
