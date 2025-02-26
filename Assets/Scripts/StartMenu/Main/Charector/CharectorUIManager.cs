using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using TMPro;
using Newtonsoft.Json.Linq;

namespace UI.Charector
{
    public class CharectorUIManager : MonoBehaviour
    {
        [SerializeField] protected InventorySlot[] charectorSlot;
        [SerializeField] protected Transform inventoryUI;
        [SerializeField] protected GameObject prefabItem;
        [SerializeField] protected GameObject prefabSlot;

        [SerializeField] protected TMP_Text textHelth;
        [SerializeField] protected TMP_Text textDamage;
        [SerializeField] protected SOStat statPlayer;

        private void Start()
        {
            CreateInventory();
            statPlayer.OnChangeStat += UpdateTextHelth;
            statPlayer.OnChangeStat += UpdateTextDamage;
            textHelth.text = statPlayer.GetStatValue(EnumName.Stat.HpMax).ToString();
            textDamage.text = statPlayer.GetStatValue(EnumName.Stat.Damage).ToString();
        }

        [Button]
        protected void CreateInventory() {
            InventorySlot slot;
            DraggableItem drag;
            foreach (SOItem item in Inventory.instance.ItemsCurrent)
            {
                slot = Instantiate(prefabSlot, inventoryUI).GetComponent<InventorySlot>();
                drag = Instantiate(prefabItem, slot.transform).GetComponent<DraggableItem>();
                slot.Initialized(drag);
                drag.Initialized(item,slot);
            }
        }

        protected void UpdateTextHelth(EnumName.Stat stat, float value)
        {
            if (stat == EnumName.Stat.HpMax)
            {
                textHelth.text = value.ToString();
            }
        }

        protected void UpdateTextDamage(EnumName.Stat stat, float value)
        {
            if (stat == EnumName.Stat.Damage)
            {
                textDamage.text = value.ToString();
            }
        }
    }
}
