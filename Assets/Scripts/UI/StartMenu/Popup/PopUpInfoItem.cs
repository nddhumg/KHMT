using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInfoItem : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private TMP_Text textName;

    [Header("Type")]
    [SerializeField] private Image iconType;
    [SerializeField] private TMP_Text textType;

    [Header("Stat")]
    [SerializeField] private Image iconStat;
    [SerializeField] private TMP_Text textStat;

    [Header("Button")]
    [SerializeField] private Button btnEquip;
    [SerializeField] private Button btnDequip;
    [SerializeField] private Button btnLevelUp;
    [SerializeField] private Button btnLevelUpMax;

    [SerializeField] private Button btnCancel;

    private IItemData data;

    private void Start()
    {
        btnCancel.onClick.AddListener(() => gameObject.SetActive(false));
        btnEquip.onClick.AddListener(Equip);
        btnDequip.onClick.AddListener(Dequip);
    }

    public void SetInfo(IItemData data, bool isEquip)
    {
        this.data = data;
        IEquipmentStats equipmentStats = InventoryManager.instance.SOEquipmentStats.GetEquipmentStats(data.Model.Type);

        iconItem.sprite = data.Model.Icon;
        textName.text = data.Model.NameItem;

        iconStat.sprite = equipmentStats.IconStat;
        textStat.text = equipmentStats.GetBonus(data.Level).ToString();

        textType.text = data.Model.Type.ToString();
        iconType.sprite = equipmentStats.IconType;

        btnEquip.gameObject.SetActive(!isEquip);
        btnDequip.gameObject.SetActive(isEquip);
    }


    public void Equip()
    {
        data.Equip();
        gameObject.SetActive(false);
    }

    public void Dequip()
    {
        data.Dequip();
        gameObject.SetActive(false);
    }

}
