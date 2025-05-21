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

    [Header("Level")]
    [SerializeField] private TMP_Text textLevel;

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
        btnLevelUp.onClick.AddListener(LevelUp);

        
    }

    public void SetInfo(IItemData data, bool isEquip)
    {

        this.data = data;
        IEquipmentStats equipmentStats = data.BonusStatData.EquipmentStats;

        iconItem.sprite = data.ModelData.Icon;
        textName.text = data.ModelData.NameItem;

        iconStat.sprite = equipmentStats.IconStat;
        UpdateTextStatBonus();

        textType.text = data.ModelData.Type.ToString();
        iconType.sprite = equipmentStats.IconType;

        UpdateTextLevel();

        btnEquip.gameObject.SetActive(!isEquip);
        btnDequip.gameObject.SetActive(isEquip);
    }

    public void LevelUp(){
        data.LevelData.LevelUp();
        UpdateTextLevel();
        UpdateTextStatBonus();
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

    protected void UpdateTextStatBonus() {
        textStat.text = data.BonusStatData.GetBonusStat().ToString();
    }

    protected void UpdateTextLevel() { 
        textLevel.text = "Level: "+ data.LevelData.Level.ToString();
    }
}
