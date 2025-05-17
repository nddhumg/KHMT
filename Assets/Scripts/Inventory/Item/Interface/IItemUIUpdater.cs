using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Inventory;

namespace UI.Charector
{
    public interface IItemUIUpdater
    {
        void Init(IItemData data, bool isEquiped);
    }
}
