using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

	public virtual GameObject GetFromPool(GameObject prefab, Vector3 pos, Quaternion rot){
		if (!pool.ContainsKey (prefab)) {
			pool.Add(prefab,new List<GameObject>());
		}
		foreach (GameObject obj in pool[prefab]) {
			if (obj.activeSelf) {
				continue;
			}
			obj.SetActive (true);
			obj.transform.SetPositionAndRotation (pos, rot);
			return obj;
		}
		GameObject prefabClone = Instantiate (prefab, pos, rot);
		prefabClone.transform.SetParent (holder);
		prefabClone.SetActive (true);
		pool [prefab].Add (prefabClone);
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
