using UnityEngine;
using Ndd.Stat;


[CreateAssetMenu(fileName = "UpgradeStat", menuName = "SO/Upgrade/Stat")]
public class SOUpgradeStats : SOUpgrade
{
    [SerializeField] private StatName statName;
    [SerializeField] private float statIncreaseValue;
    [SerializeField] private bool percentageIncrease;

    public override void ApplyUpgrade(Player player)
    {   
        if (!percentageIncrease)
        {
            player.StatCurrent.IncreaseStat(statName, statIncreaseValue);
        }
        else
        {
            player.StatCurrent.PercentageIncreaseStat(statName, statIncreaseValue);
        }
    }

    public override string GetDescription(Player player)
    {
        string stat = LocalizationManager.instance.GetMesage(statName.ToString());
        if (stat == string.Empty)
        {
            Debug.LogWarning($"Not key: {statName} in Localization ");
        }
        else
        {
            stat = stat.Substring(0, 1).ToLower() + stat.Substring(1);
        }
        if (percentageIncrease == false)
        {
            return LocalizationManager.instance.GetMesage("Increase") + " " + stat;
        }
        else
        {
            return LocalizationManager.instance.GetMesage("PercentageIncrease") + " " + stat;
        }
    }
}
