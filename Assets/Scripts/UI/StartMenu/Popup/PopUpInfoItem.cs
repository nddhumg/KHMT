using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInfoItem : MonoBehaviour
{
    [SerializeField] protected Image iconItem;
    [SerializeField] protected TMP_Text textName;

    [Header("Type")]
    [SerializeField] protected Image iconType;
    [SerializeField] protected TMP_Text textType;

    [Header("Stat")]
    [SerializeField] protected Image iconStat;
    [SerializeField] protected TMP_Text textStat;

    [SerializeField] private Button btnCancel;

    protected IItemModel modelItemSelect;

    protected virtual void Start()
    {
        btnCancel.onClick.AddListener(() => gameObject.SetActive(false));
        
    }

    public virtual void SetInfo(IItemModel model) {
        modelItemSelect = model;
        IEquipmentStats equipmentStats = InventoryManager.instance.SOEquipmentStats.GetEquipmentStats(model.Type);
        iconItem.sprite = model.Icon;
        textName.text = model.NameItem;

        iconStat.sprite = equipmentStats.IconStat;

        textType.text = model.Type.ToString();
        iconType.sprite = equipmentStats.IconType;
    }

    protected virtual void UpdateTextStatBonus()
    {
        textStat.text = InventoryManager.instance.SOEquipmentStats.GetEquipmentStats(modelItemSelect.Type).GetBonus(0).ToString();
    }

}
