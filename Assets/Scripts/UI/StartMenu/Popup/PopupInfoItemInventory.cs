using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfoItemInventory : PopUpInfoItem
{
    [Header("Level")]
    [SerializeField] protected TMP_Text textLevel;
    [Header("Button")]
    [SerializeField] private Button btnEquip;
    [SerializeField] private Button btnDequip;
    [SerializeField] private Button btnLevelUp;
    [SerializeField] private Button btnLevelUpMax;

    protected IItemData dataItemSelect;
    protected override void Start()
    {
        base.Start();
        btnEquip.onClick.AddListener(Equip);
        btnDequip.onClick.AddListener(Dequip);
        btnLevelUp.onClick.AddListener(LevelUp);
    }


    public virtual void SetInfo(IItemData data, bool isEquip) {
        this.dataItemSelect = data;
        SetInfo(data.ModelData);
        textLevel.text = data.LevelData.Level.ToString();
        btnEquip.gameObject.SetActive(!isEquip);
        btnDequip.gameObject.SetActive(isEquip);
    }
    protected void Equip()
    {
        dataItemSelect.Equip();
        gameObject.SetActive(false);
    }
    protected void LevelUp()
    {
        dataItemSelect.LevelData.LevelUp();
        UpdateTextLevel();
        UpdateTextStatBonus();
    }
    protected void Dequip()
    {
        dataItemSelect.Dequip();
        gameObject.SetActive(false);
    }
    protected void UpdateTextLevel()
    {
        textLevel.text = "Level: " + dataItemSelect.LevelData.Level.ToString();
    }

    protected override void UpdateTextStatBonus()
    {
        textStat.text = InventoryManager.instance.SOEquipmentStats.GetEquipmentStats(modelItemSelect.Type).GetBonus(dataItemSelect.LevelData.Level).ToString();
    }
}
