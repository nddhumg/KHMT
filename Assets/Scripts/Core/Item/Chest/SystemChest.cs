using Ndd.Random;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemChest : Singleton<SystemChest>
{
    [SerializeField] private UIBoxChest[] boxChests;
    [SerializeField] private Sprite iconCoin;
    [SerializeField] private Sprite iconCoinVip;
    [SerializeField] private List<ChestRate> boxRates = new List<ChestRate>();
    private IRandomSelector<ChestRate> boxRate = new GuaranteedSelectorRandom<ChestRate>();
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

    void CreateChestRate()
    {
        boxRate.AddItem(new ChestSkillRate(), 0.3f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.Coin, 250), 0.3f);
        //boxRates.Add(new ChestSkillRate(0.3f));
        //boxRates.Add(new ChestResourceRate(EnumName.ResourceName.Coin, 250, 0.3f));
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.Coin, 275), 0.2f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.Coin, 400), 0.1f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.Coin, 1000), 0.05f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.CoinVip, 1), 0.03f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.CoinVip, 2), 0.01f);
        boxRate.AddItem(new ChestResourceRate(EnumName.ResourceName.CoinVip, 3), 0.01f);
    }

    void NoMoreSkillUpgrades()
    {
        boxRate.RemoveItemAt(0);
        boxRate.SetRateItem(0, 0.4f);
        boxRate.SetRateItem(1, 0.3f);
        boxRate.SetRateItem(2, 0.2f);
        //boxRates.RemoveAt(0);
        //boxRates[0].Rate = 0.4f;
        //boxRates[1].Rate = 0.3f;
        //boxRates[2].Rate = 0.2f;
    }

    [Button]
    public void CreateChest()
    {
        panel.SetActive(true);

        foreach (UIBoxChest boxChest in boxChests)
        {
            CreateRandomBoxChest(boxChest);
        }

        GameSystem.Pause();
    }

    public void CloseChest()
    {
        panel.SetActive(false);
        GameSystem.RePause();
    }

    void CreateRandomBoxChest(UIBoxChest uiBox)
    {
        if (!UpgradeSystem.instance.CanUpgradeSkill())
        {
            NoMoreSkillUpgrades();
        }
        ChestRate chest = boxRate.GetRandomItem();
        uiBox.SetIcon(chest.GetIcon());
        uiBox.SetText(chest.GetStringValue());
        chest.GenerateChestReward();
    }

}
