using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;


namespace Systems.Inventory
{
    public interface IEquipmentStats
    {
        EnumName.EquipmentType Type { get; }

        StatName StatBonus { get; }

        float GetBonus(int rarity);

        float GetBonusLevelUp(int rarity);

        Sprite IconType { get; }

        Sprite IconStat { get; }
    }
}
