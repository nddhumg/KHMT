using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Charector
{
    public class InventoryEquip : InventorySlot
    {
        [SerializeField] protected EnumName.EquipmentType typeItem;

        public override void ItemSwap(DraggableItem draggable)
        {
            draggable.ItemInfo.Dequip();
            base.ItemSwap(draggable);
            this.draggableItem.ItemInfo.Equip();
        }

        public override bool CanItemSwap(DraggableItem draggable)
        {
            return draggable.ItemInfo.equipmentType == typeItem && base.CanItemSwap(draggable);
        }
    }
}
