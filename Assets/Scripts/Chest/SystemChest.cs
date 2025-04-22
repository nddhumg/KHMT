using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SystemChest : Singleton<SystemChest>
{
    [SerializeField] private UIBoxChest[] boxChests;
    [SerializeField] private Sprite iconCoin;
    [SerializeField] private Sprite iconCoinVip;
    [SerializeField] private List<ChestRate> boxRates = new List<ChestRate>();
    [SerializeField] private GameObject panel;
    [SerializeField] private Button btnClaim;
    public Sprite IconCoin => iconCoin;
    public Sprite IconCoinVip => iconCoinVip;

    private void Start()
    {
        panel.SetActive(false);
        CreateChestRate();
        btnClaim.onClick.AddListener(CloseChest);
    }

    void CreateChestRate() {
        boxRates.Add(new ChestSkillRate(0.3f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.Coin, 250, 0.3f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.Coin, 275, 0.2f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.Coin, 400, 0.1f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.Coin, 1000, 0.05f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.CoinVip, 1, 0.03f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.CoinVip, 2, 0.01f));
        boxRates.Add(new ChestResourceRate(EnumName.ResourceName.CoinVip, 3, 0.01f));
    }

    void NoMoreSkillUpgrades() {
        boxRates.RemoveAt(0);
        boxRates[0].Rate = 0.4f;
        boxRates[1].Rate = 0.3f;
        boxRates[2].Rate = 0.2f;
    }

    [Button]
    public void CreateChest() {
        panel.SetActive(true);

        foreach (UIBoxChest boxChest in boxChests) {
            CreateRandomBoxChest(boxChest);
        }

        GameSystem.Pause();
    }

    public void CloseChest() { 
        panel.SetActive(false);
        GameSystem.RePause();
    }

    void CreateRandomBoxChest(UIBoxChest uiBox) {
        float temp = 0;
        float random = Random.value;
        if (!UpgradeSystem.instance.CanUpgradeSkill()) { 
            NoMoreSkillUpgrades();
        }
        foreach (ChestRate box in boxRates)
        {
            temp += box.Rate;
            if (random <= temp)
            {
                uiBox.SetIcon(box.GetIcon());
                uiBox.SetText(box.GetStringValue());
                box.GenerateChestReward();
                return;
            }
        }
    }

}
