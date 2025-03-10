using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;

namespace Inventory
{
    public class InventoryEquip : InventorySlot
    {
        [SerializeField] protected EnumName.EquipmentType typeItem;

        public override void DropItem(UIItem item)
        {
            InventoryManager.instance.DequipItem(this.item?.info);
            base.DropItem(item);
            InventoryManager.instance.EquipItem(this.item.info);
        }

        protected override bool CanItemSwap(UIItem item)
        {
            return item.info.equipmentType == typeItem && base.CanItemSwap(item);
        }
    }
}
