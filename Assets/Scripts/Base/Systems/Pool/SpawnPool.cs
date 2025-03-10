using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPool<T> : Singleton<T> where T : MonoBehaviour
{
    [SerializeField] protected Dictionary<GameObject, List<GameObject>> pool;
    [SerializeField] protected Transform holder;

    protected virtual void Reset()
    {
        LoadHolder();
    }

    protected override void Awake()
    {
        base.Awake();
        pool = new Dictionary<GameObject, List<GameObject>>();

    }

    public virtual GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, out bool isGetFromPool)
    {
        GameObject obj = Spawn(prefab,out isGetFromPool);
        obj.transform.SetPositionAndRotation(pos, rot);
        return obj;
    }
    public virtual GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot) => Spawn(prefab, pos, rot, out _);
    
    public virtual GameObject Spawn(GameObject prefab, out bool isGetFromPool)
    {
        if (!pool.TryGetValue(prefab, out var list))
        {
            list = new List<GameObject>();
            pool[prefab] = list;
        }

        foreach (var obj in list)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                obj.transform.SetParent(holder);
                isGetFromPool = true;
                return obj;
            }
        }

        var prefabClone = Instantiate(prefab);
        prefabClone.SetActive(true);
        list.Add(prefabClone);
        prefabClone.transform.SetParent(holder);
        isGetFromPool = false;
        return prefabClone;
    }
    public virtual GameObject Spawn(GameObject prefab) => Spawn(prefab, out _);


    public virtual void ClearPool(GameObject prefab)
    {
        pool[prefab].Clear();
    }

    private void LoadHolder()
    {
        if (this.holder != null)
            return;
        this.holder = transform.Find("Holder");
        if (this.holder == null)
        {
            GameObject go = new GameObject("Holder");
            go.transform.SetParent(transform);
            this.holder = go.transform;
        }
        Debug.LogWarning("Add Holder", gameObject);
    }

}
