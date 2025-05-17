using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory
{
    [CreateAssetMenu(menuName = "SO/Item/Shoes", fileName = "shoes")]
    public class SOItemShoes : SOItem
    {
        [SerializeField] protected EnumName.ShoesName shoesName;

        public SOItemShoes() : base(EnumName.EquipmentType.Shoes)
        {
        }

        public override string NameItem => shoesName.ToString();
    }
}
