using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Systems.Inventory
{
    public interface IItemData
    {
        IItemModel Model { get; }

        int Level { get; }

        void Equip();
        void Dequip();
    }
}

