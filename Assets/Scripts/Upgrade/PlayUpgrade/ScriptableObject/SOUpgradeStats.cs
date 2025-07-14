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
        if(percentageIncrease == false)
            return "Increase " + statName.ToString() + " by " + statIncreaseValue;
        else
            return "Increase " + statName.ToString() + " by " + statIncreaseValue + "%";
    }
}
