using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;

namespace Systems.Inventory
{
    public interface IItemDataBase
    {
        IItemModel GetModelByName(string name);
    }
}
