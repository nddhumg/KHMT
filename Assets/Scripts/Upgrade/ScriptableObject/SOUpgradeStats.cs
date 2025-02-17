using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "UpgradeStat", menuName = "SO/Upgrade/Stat")]
public class SOUpgradeStats : SOUpgrade
{
    [SerializeField] private EnumName.Stat statName;
    [SerializeField] private float statIncreaseValue;
    [SerializeField] private bool percentageIncrease;
    public override void ApplyUpgrade()
    {   
        if (!percentageIncrease)
        {
            Player.instance.StatsManager.IncreaseStat(statName, statIncreaseValue);
        }
        else
        {
            Player.instance.StatsManager.PercentageIncreaseStat(statName, statIncreaseValue);
        }
    }

    public override string GetDescription()
    {
        if(percentageIncrease == false)
            return "Increase " + statName.ToString() + " by " + statIncreaseValue;
        else
            return "Increase " + statName.ToString() + " by " + statIncreaseValue + "%";
    }
}
