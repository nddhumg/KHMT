using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ndd.Pool
{
    public class PoolGameObject : IPoolObject<GameObject, GameObject>
    {
        [SerializeField] protected Dictionary<GameObject, List<GameObject>> pool;
        [SerializeField] protected Transform holder;

        public Dictionary<GameObject, List<GameObject>> Pool => pool;

        public PoolGameObject(Transform holder)
        {
            pool = new();
            this.holder = holder;
        }

        public virtual GameObject Take(GameObject prefab, Vector3 pos, Quaternion rot, out bool isGetFromPool)
        {
            GameObject obj = Take(prefab, out isGetFromPool);
            obj.transform.SetPositionAndRotation(pos, rot);
            return obj;
        }
        public virtual GameObject Take(GameObject prefab, Vector3 pos, Quaternion rot) => Take(prefab, pos, rot, out _);

        public virtual GameObject Take(GameObject prefab, out bool isGetFromPool)
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

            var prefabClone = UnityEngine.Object.Instantiate(prefab);
            prefabClone.SetActive(true);
            list.Add(prefabClone);
            prefabClone.transform.SetParent(holder);
            isGetFromPool = false;
            return prefabClone;
        }
        public virtual GameObject Take(GameObject prefab) => Take(prefab, out _);

        public virtual void ClearPool(GameObject prefab)
        {
            foreach (GameObject obj in pool[prefab])
            {
                Object.Destroy(obj);
            }
            pool[prefab].Clear();
        }

    }
}