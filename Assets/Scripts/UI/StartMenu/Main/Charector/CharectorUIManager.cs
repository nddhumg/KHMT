using UnityEngine;
using TMPro;
using Systems.Inventory;

namespace UI.Charector
{
    public class CharectorUIManager : MonoBehaviour
    {
        //[SerializeField] protected InventorySlot[] charectorSlot;
        [SerializeField] protected Transform inventoryUI;
        [SerializeField] protected GameObject prefabSlot;

        [SerializeField] protected TMP_Text textHelth;
        [SerializeField] protected TMP_Text textDamage;
        [SerializeField] protected SOStat statPlayer;

        [SerializeField] private PopUpInfoItem popupInfoItem;
        [SerializeField] private ItemSlot[] slotItemsEquip;


        private ItemSlot slotSelect;

        private void Start()
        {
            InventoryManager inventoryManager = InventoryManager.instance;
            inventoryManager.OnEquip += EquipItem;
            inventoryManager.OnDequip += DequipItem;
            inventoryManager.OnSwapItem += SwapItem;
            ItemSlot.SetUIManager(this);
            CreateInventory();
            CreateItemEquip();
            inventoryManager.onChangeStat += statPlayer.SetStatValue;
            statPlayer.OnChangeStat += UpdateTextHelth;
            statPlayer.OnChangeStat += UpdateTextDamage;
            textHelth.text = statPlayer.GetStatValue(EnumName.Stat.HpMax).ToString();
            textDamage.text = statPlayer.GetStatValue(EnumName.Stat.Damage).ToString();
        }

        private void OnDisable()
        {
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
                slot.Init(item, false);
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
                slotItemsEquip[i].Init(item, true);
                slotItemsEquip[i].gameObject.SetActive(true);
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

        protected void EquipItem(IItemData data)
        {
            ItemSlot slot = slotItemsEquip[(int)data.Model.Type];
            slot.Init(data, true);
            slot.gameObject.SetActive(true);
            Destroy(slotSelect.gameObject);
        }

        protected void DequipItem(IItemData data) { 
            ItemSlot slotEquip = slotItemsEquip[(int)data.Model.Type];
            slotEquip.gameObject.SetActive(false);
            IItemUIUpdater slotItem =  Instantiate(prefabSlot, inventoryUI).GetComponent<IItemUIUpdater>();
            slotItem.Init(data, false);
        }

        protected void SwapItem(IItemData data, IItemData dataOld) {
            DequipItem(dataOld);
            EquipItem(data);
        }
    }
}
