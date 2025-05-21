using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Systems.Inventory
{
    public interface IEquipmentStats
    {
        EnumName.EquipmentType Type { get; }

        EnumName.Stat StatBonus { get; }

        float GetBonus(int rarity);

        float GetBonusLevelUp(int rarity);

        Sprite IconType { get; }

        Sprite IconStat { get; }
    }
}
