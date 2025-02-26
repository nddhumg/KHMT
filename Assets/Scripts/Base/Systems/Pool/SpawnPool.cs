using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class SpawnPool<T> : Singleton<T> where T : MonoBehaviour {
	[SerializeField] protected Dictionary<GameObject,List<GameObject>> pool;
	[SerializeField] protected Transform holder;

	protected virtual void Reset(){
		LoadHolder ();
	}

	protected override void Awake(){
		base.Awake ();
		pool = new Dictionary<GameObject , List<GameObject>> ();

	}

	public virtual GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot){
		GameObject obj = Spawn(prefab);
        obj.transform.SetPositionAndRotation(pos, rot);
		return obj;
    }

	public virtual GameObject Spawn(GameObject prefab) {
        if (!pool.ContainsKey(prefab))
        {
            pool.Add(prefab, new List<GameObject>());
        }
        foreach (GameObject obj in pool[prefab])
        {
            if (obj.activeSelf)
            {
                continue;
            }
            obj.SetActive(true);
            obj.transform.SetParent(holder);
            return obj;
        }
        GameObject prefabClone = Instantiate(prefab);
        prefabClone.SetActive(true);
        pool[prefab].Add(prefabClone);
		prefabClone.transform.SetParent (holder);
        return prefabClone;
    }

	public virtual void ClearPool(GameObject prefab){
		pool [prefab].Clear ();
	}

	private void LoadHolder(){
		if (this.holder != null)
			return;
		this.holder = transform.Find ("Holder");
		if (this.holder == null) {
			GameObject go = new GameObject ("Holder");
			go.transform.SetParent (transform);
			this.holder = go.transform;
		}
		Debug.LogWarning ("Add Holder", gameObject);
	}

}
