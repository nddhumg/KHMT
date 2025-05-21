using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Systems.Inventory
{
    public interface IItemData
    {
        IItemModel ModelData { get; }

        IItemLevel LevelData { get; }

        IItemBonusStat BonusStatData { get; }

        void Equip();
        void Dequip();

    }
}

