using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Ndd.Random
{
    [System.Serializable]
    public class ObjectRate<T> : IObjectRate<T> where T : UnityEngine.Object
    {
        [SerializeField] private float rate;
        [SerializeField] private T obj;
        public float Rate => rate;
        public T Object => obj;
    }
}
