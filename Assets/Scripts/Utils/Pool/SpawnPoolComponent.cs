using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoolComponent<T,TObject> : Singleton<T> where T : MonoBehaviour where TObject : Component
{
    protected Dictionary<TObject, List<TObject>> pool;
    [SerializeField] protected Transform holder;

    protected virtual void Reset()
    {
        LoadHolder();
    }

    protected override void Awake()
    {
        base.Awake();
        pool = new Dictionary<TObject, List<TObject>>();

    }


    public virtual TObject Spawn(TObject prefab, Vector3 pos, Quaternion rot, out bool isGetFromPool)
    {
        TObject obj = Spawn(prefab,out isGetFromPool);
        obj.transform.SetPositionAndRotation(pos, rot);
        return obj;
    }
    public virtual TObject Spawn(TObject prefab, Vector3 pos, Quaternion rot) => Spawn(prefab, pos, rot, out _);
    
    public virtual TObject Spawn(TObject prefab, out bool isGetFromPool)
    {
        if (!pool.TryGetValue(prefab, out var list))
        {
            list = new List<TObject>();
            pool[prefab] = list;
        }

        foreach (var obj in list)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                obj.transform.SetParent(holder);
                isGetFromPool = true;
                return obj;
            }
        }

        var prefabClone = Instantiate(prefab);
        prefabClone.gameObject.SetActive(true);
        list.Add(prefabClone);
        prefabClone.transform.SetParent(holder);
        isGetFromPool = false;
        return prefabClone;
    }
    public virtual TObject Spawn(TObject prefab) => Spawn(prefab, out _);


    public virtual void ClearPool(TObject prefab)
    {
        foreach (var obj in pool[prefab]) { 
            Destroy(obj.gameObject);
        }
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
