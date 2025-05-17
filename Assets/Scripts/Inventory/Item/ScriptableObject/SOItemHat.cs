using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Inventory
{
    [CreateAssetMenu(menuName = "SO/Item/Hat", fileName = "hat")]
    public class SOItemHat : SOItem
    {
        [SerializeField] protected EnumName.HatName hatName;

        public SOItemHat() : base(EnumName.EquipmentType.Hat)
        {
        }

        public override string NameItem => hatName.ToString();
    }
}
