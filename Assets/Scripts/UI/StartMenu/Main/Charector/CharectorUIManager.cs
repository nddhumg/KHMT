using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
using TMPro;
using Systems.Inventory;

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
            CreateItemEquip();
            statPlayer.OnChangeStat += UpdateTextHelth;
            statPlayer.OnChangeStat += UpdateTextDamage;
            textHelth.text = statPlayer.GetStatValue(EnumName.Stat.HpMax).ToString();
            textDamage.text = statPlayer.GetStatValue(EnumName.Stat.Damage).ToString();
        }

        [Button]
        protected void CreateInventory() {
            InventorySlot slot;
            UIItem itemUI;
            foreach (SOItem item in InventoryManager.instance.ItemsCurrent)
            {
                if (item == null) {
                    Debug.LogError("Empty inventory list",gameObject);
                    continue;
                }
                slot = Instantiate(prefabSlot, inventoryUI).GetComponent<InventorySlot>();
                itemUI = Instantiate(prefabItem, slot.transform).GetComponent<UIItem>();
                slot.Initialized(itemUI);
                itemUI.Initialized(slot, item);
            }
        }

        [Button]
        protected void CreateItemEquip()
        {
            InventorySlot slot;
            UIItem itemUI;
            SOItem item;
            for (int i = 0; i< 4; i++)
            {
                item = InventoryManager.instance.EquippedItem[i];
                if (item == null)
                    continue;
                slot = charectorSlot[i];
                itemUI = Instantiate(prefabItem, slot.transform).GetComponent<UIItem>();
                charectorSlot[0].Initialized(itemUI);
                itemUI.Initialized(slot, item);
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
