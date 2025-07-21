using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgradeUI : MonoBehaviour
{
    [SerializeField] protected Image iconInfo;
    [SerializeField] protected TMP_Text textLevelInfo;
    [SerializeField] protected TMP_Text textDescriptionInfoSingle;
    [SerializeField] protected TMP_Text textDescriptionInfoDouble1;
    [SerializeField] protected TMP_Text textDescriptionInfoDouble2;
    [SerializeField] protected GameObject goTextSingle;
    [SerializeField] protected GameObject goTextDouble;

    [SerializeField] protected Button btnLevelUp;
    [SerializeField] protected TMP_Text TextPrice;

    [SerializeField] protected GameObject slotPrefab;
    [SerializeField] protected Transform slotParent;


    protected Dictionary<string, GlobalUpgradeSlot> slots = new();
    protected IGlobalUpgrade globalUpgradeSelection;

    void Start()
    {
        btnLevelUp.onClick.AddListener(OnClickLevelUp);
        CreateSlot(GlobalUpgradeManager.instance.GlobalUpgradeData.GlobalUpgradeModel);
        Selection(GlobalUpgradeManager.instance.GlobalUpgradeData.GlobalUpgradeModel[0]);
    }


    public void UpdateInfo(IGlobalUpgrade upgradeSelection)
    {
        iconInfo.sprite = upgradeSelection.Model.Icon;

        bool isLock = upgradeSelection.LevelCurrent == 0;
        bool isMax = upgradeSelection.LevelCurrent == upgradeSelection.Model.LevelMax;
        if (isMax || isLock)
        {
            btnLevelUp.interactable = !isMax;
            goTextSingle.SetActive(true);
            goTextDouble.SetActive(false);
            textLevelInfo.text = isMax ? "Max" : $"0 / {upgradeSelection.Model.LevelMax}";
            textDescriptionInfoSingle.text = upgradeSelection.Model.GlobalUpgradeLevels[isMax ? upgradeSelection.LevelCurrent - 1 : upgradeSelection.LevelCurrent].Description;
        }
        else
        {
            btnLevelUp.interactable = true;
            textLevelInfo.text = upgradeSelection.LevelCurrent + " / " + upgradeSelection.Model.LevelMax;
            goTextSingle.SetActive(false);
            goTextDouble.SetActive(true);
            textDescriptionInfoDouble1.text = upgradeSelection.Model.GlobalUpgradeLevels[upgradeSelection.LevelCurrent - 1].Description;
            textDescriptionInfoDouble2.text = upgradeSelection.Model.GlobalUpgradeLevels[upgradeSelection.LevelCurrent].Description;
        }
        slots[upgradeSelection.Name].UpdateInfo();
    }


    public void CreateSlot(IEnumerable<IGlobalUpgrade> upgrades)
    {
        foreach (var upgrade in upgrades)
        {
            GlobalUpgradeSlot slot = Instantiate(slotPrefab, slotParent).GetComponent<GlobalUpgradeSlot>();
            slot.Init(upgrade,this);
            slots.Add(upgrade.Model.Name, slot);
        }
    }

    public void CreateSlot(IEnumerable<GlobalUpgrade> upgrades)
    {
        foreach (var upgrade in upgrades)
        {
            GlobalUpgradeSlot slot = Instantiate(slotPrefab, slotParent).GetComponent<GlobalUpgradeSlot>();
            slot.Init(upgrade,this);
            slots.Add(upgrade.Model.Name, slot);
        }
    }

    public void Selection(IGlobalUpgrade globalUpgrade) {
        globalUpgradeSelection = globalUpgrade;
        UpdateInfo(globalUpgrade);
    }

    protected void OnClickLevelUp()
    {
        if (GlobalUpgradeManager.instance.LevelUpUpgradeSelection(globalUpgradeSelection))
        {
            UpdateInfo(globalUpgradeSelection);
            MusicManager.instance.PlaySFX(MusicKey.UpgradeGlobal);
        }
        else {
            StartSceenManager.instance.OpenPopupDebug(GameMessages.GetMesage(MessageKey.NotEnoughGold));
        }
    }

}
