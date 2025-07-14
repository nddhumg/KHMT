using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UpgradeSkill", menuName = "SO/Upgrade/Skill")]
public class SOUpgradeSkill : SOUpgrade
{
    [SerializeField] protected EnumName.Skill skillName;
    [SerializeField] protected string[] description;
    [SerializeField] private GameObject prefabSkill;

    public EnumName.Skill SkillName => skillName;

    public override void ApplyUpgrade(Player player)
    {
        player.SkillManager.Upgrade(skillName, prefabSkill,this);
        if (!player.SkillManager.CanLevelUp(SkillName)) {
            UpgradeSystem.instance.RemoveUpgradeSkill(this);
        }
    }

    public override string GetDescription(Player player)
    {
        return description[player.SkillManager.GetLevelSkill(skillName)];
    }
}
