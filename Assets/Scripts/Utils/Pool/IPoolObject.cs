using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Pool
{
    public interface IPoolObject<TKey, TValue>
    {
        public Dictionary<TKey, List<TValue>> Pool { get; }
        
        public TValue Take(TKey prefabKey, Vector3 pos, Quaternion rot, out bool fromPool);
        public TValue Take(TKey prefabKey, Vector3 pos, Quaternion rot);
        public TValue Take(TKey prefabKey, out bool isGetFromPool);
        public TValue Take(TKey prefabKey);

        public void ClearPool(TKey prefabKey);


    }
}
