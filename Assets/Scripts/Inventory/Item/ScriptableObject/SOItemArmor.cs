using EnumName;
using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;
namespace Systems.Inventory
{
    [CreateAssetMenu(menuName = "SO/Inventory/Item/Armor", fileName = "armor")]
    public class SOItemArmor : SOItem
    {
        [SerializeField] protected EnumName.ArmorName armorName;

        public SOItemArmor() : base(EnumName.EquipmentType.Armor)
        {
        }

        public override string NameItem => armorName.ToString();
    }
}
