using UnityEngine;
using TMPro;
using Systems.Inventory;
using Ndd.Stat;

namespace UI.Charector
{
    public class CharectorUIManager : MonoBehaviour
    {
        [SerializeField] protected Transform inventoryUI;
        [SerializeField] protected GameObject prefabSlot;

        [SerializeField] protected TMP_Text textHelth;
        [SerializeField] protected TMP_Text textDamage;

        [SerializeField] private PopupInfoItemInventory popupInfoItem;
        [SerializeField] private ItemSlot[] slotItemsEquip;


        private ItemSlot slotSelect;

        private void Start()
        {
            IStat statPlayer = GameController.instance.StatPlayer;
            InventoryManager inventoryManager = InventoryManager.instance;
            inventoryManager.OnEquip += EquipItem;
            inventoryManager.OnDequip += DequipItem;
            inventoryManager.OnSwapItem += SwapItem;
            ItemSlot.SetUIManager(this);
            CreateInventory();
            CreateItemEquip();

            statPlayer.OnStatUpdatedValue += UpdateTextHelth;
            statPlayer.OnStatUpdatedValue += UpdateTextDamage;


            textHelth.text = statPlayer.GetStatValue(StatName.HpMax).ToString();
            textDamage.text = statPlayer.GetStatValue(StatName.Damage).ToString();
        }


        [Button]
        protected void CreateInventory()
        {
            IItemUIUpdater slot;
            foreach (Item item in InventoryManager.instance.ItemsCurrent)
            {
                if (item == null)
                {
                    Debug.LogError("Empty inventory list", gameObject);
                    continue;
                }
                slot = Instantiate(prefabSlot, inventoryUI).GetComponent<IItemUIUpdater>();
                slot.Init(item, item, false);
            }
        }

        public void OpenPopupInfoItem(IItemData data, ItemSlot slot)
        {
            popupInfoItem.gameObject.SetActive(true);
            popupInfoItem.SetInfo(data, slot.IsEquiped);
            slotSelect = slot;

        }

        [Button]
        protected void CreateItemEquip()
        {
            for (int i = 0; i < 4; i++)
            {
                Item item = InventoryManager.instance.EquippedItem[i];
                if (item.Name == string.Empty)
                    continue;
                slotItemsEquip[i].Init(item, item, true);
                slotItemsEquip[i].gameObject.SetActive(true);
            }
        }
        protected void UpdateTextHelth(StatName stat, float value)
        {
            if (stat == StatName.HpMax)
            {
                textHelth.text = value.ToString();
            }
        }

        protected void UpdateTextDamage(StatName stat, float value)
        {
            if (stat == StatName.Damage)
            {
                textDamage.text = value.ToString();
            }
        }

        protected void EquipItem(Item item)
        {
            ItemSlot slot = slotItemsEquip[(int)item.ModelData.Type];
            slot.Init(item, item, true);
            slot.gameObject.SetActive(true);    
            Destroy(slotSelect.gameObject);
            MusicManager.instance.PlaySFX(MusicKey.Equip);
        }

        protected void DequipItem(Item item)
        {
            ItemSlot slotEquip = slotItemsEquip[(int)item.ModelData.Type];
            slotEquip.gameObject.SetActive(false);
            IItemUIUpdater slotItem = Instantiate(prefabSlot, inventoryUI).GetComponent<IItemUIUpdater>();
            slotItem.Init(item, item, false);
        }

        protected void SwapItem(Item data, Item dataOld)
        {
            DequipItem(dataOld);
            EquipItem(data);
        }
    }
}
