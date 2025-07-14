using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;
public class GlobalUpgradeManager : PersistentSingleton<GlobalUpgradeManager>
{
    [SerializeField] protected List<SOGlobalUpgradeModel> modelsContainer = new List<SOGlobalUpgradeModel>();
    [SerializeField, ReadOnly] protected GlobalUpgradeData data;
    protected IStat statBonus;
    protected GlobalUpgradeFactory factory;

    private Dictionary<string, IUpgradeOnStart> upgradeOnStart;

    public GlobalUpgradeData GlobalUpgradeData => data;
    public IStat StatBonus => statBonus;

    public Dictionary<string, IUpgradeOnStart> UpgradeOnStart => upgradeOnStart;


    protected override void Awake()
    {
        base.Awake();
        statBonus = ScriptableObject.CreateInstance<SOStat>();
    }
    private void Start()
    {
        upgradeOnStart = new();
        factory = new GlobalUpgradeFactory(statBonus, upgradeOnStart);
        ReadData();
        CreateGlobalUpgradeEffect();
    }

    private void OnApplicationQuit()
    {
        Systems.SaveLoad.SaveLoadSystem.DataService.Save<GlobalUpgradeData>(ref data);
    }

    public bool LevelUpUpgradeSelection(IGlobalUpgrade globalUpgradeLevelUp)
    {
        uint cost = globalUpgradeLevelUp.Model.GlobalUpgradeLevels[globalUpgradeLevelUp.LevelCurrent].Cost;
        if (ResourceController.instance.DecreaseResource(EnumName.ResourceName.Coin, cost))
        {
            if (IsGlobalUgradeUnlocked(globalUpgradeLevelUp))
            {
                factory.GetUpgradeEffect(globalUpgradeLevelUp.Name, globalUpgradeLevelUp.LevelCurrent).RevertEffect();
            }
            globalUpgradeLevelUp.LevelUp();
            factory.GetUpgradeEffect(globalUpgradeLevelUp.Name, globalUpgradeLevelUp.LevelCurrent).ApplyEffect();
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool IsGlobalUgradeUnlocked(IGlobalUpgrade globalUpgrade) {
        return globalUpgrade.LevelCurrent != 0;
    }

    private void ReadData()
    {
        data = Systems.SaveLoad.SaveLoadSystem.DataService.Load<GlobalUpgradeData>(this.gameObject) ?? new();
        List<GlobalUpgrade> modelTemp = new List<GlobalUpgrade>();
        foreach (IGlobalUpgradeModel model in modelsContainer)
        {
            GlobalUpgrade upgradeData = data.GlobalUpgradeModel.Find(modelData => modelData.Name == model.Name);
            if (upgradeData != default(GlobalUpgrade))
            {
                upgradeData.Init(model);
            }
            else
            {
                modelTemp.Add(new GlobalUpgrade(model, 0));
            }
        }
        data.GlobalUpgradeModel.AddRange(modelTemp);
    }

    private void CreateGlobalUpgradeEffect()
    {
        foreach (var upgrade in data.GlobalUpgradeModel)
        {
            if (upgrade.LevelCurrent == 0)
            {
                continue;
            }
            factory.GetUpgradeEffect(upgrade.Name, upgrade.LevelCurrent).ApplyEffect();
        }
    }

}
