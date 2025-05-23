using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ndd.Random
{
    public interface IObjectRate<T>
    {
        public float Rate { get; }

        public T Object { get; }
    }
}
