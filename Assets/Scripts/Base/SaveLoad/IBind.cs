using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.SaveLoad
{
    public interface ISaveable
    {
        string ID { get; set; }
    }
    public interface IBind<TData> where TData : ISaveable
    {
        string ID { get; set; }
        void Bind(TData data);
    }

}
