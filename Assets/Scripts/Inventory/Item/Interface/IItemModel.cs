using EnumName;
using UnityEngine;

namespace Systems.Inventory
{
    public interface IItemModel
    {
        string NameItem { get; }
        EquipmentType Type { get; }
        Sprite Icon { get; }
        int LevelMax { get; }


    }

}