using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgradeSlot : MonoBehaviour
{
    private IGlobalUpgrade upgrade;
    [SerializeField] protected Button btnSelection;
    [SerializeField] protected Image icon;
    [SerializeField] protected TMP_Text textLevel;
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected GlobalUpgradeUI ui;
    protected virtual void Start()
    {
        btnSelection.onClick.AddListener(Click);
    }

    public void UpdateInfo()
    {
        UpdateLevel();
    }


    public void Init(IGlobalUpgrade upgrade,GlobalUpgradeUI ui) { 
        this.upgrade = upgrade;
        icon.sprite = upgrade.Model.Icon;
        this.ui = ui;
        UpdateLevel();
    }

    public void SetTextLevel(string textLevel) { 
        this.textLevel.text = textLevel;    
    }

    protected virtual void Click()
    {
        ui.Selection(upgrade);
    }

    protected void UpdateLevel()
    {
        if (upgrade.LevelCurrent == upgrade.Model.LevelMax)
        {
            textLevel.text ="Max";
        }
        else
        {
            textLevel.text = upgrade.LevelCurrent + " / " + upgrade.Model.LevelMax;
        }
    }
}
