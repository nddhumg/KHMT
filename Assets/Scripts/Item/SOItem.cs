using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory
{
    [CreateAssetMenu(menuName = "SO/Item/Appare")]
    public class SOItem : ScriptableObject
    {
        public EnumName.Item nameItem;
        public Sprite icon;
        public EnumName.EquipmentType equipmentType;
        public List<StatEntry> bonusStat;

    }
}
