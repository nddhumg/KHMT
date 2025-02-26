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
    public override void ApplyUpgrade()
    {
        Player.instance.SkillManager.Upgrade(skillName, prefabSkill);
    }

    public override string GetDescription()
    {
        return description[Player.instance.SkillManager.GetLevelSkill(skillName)];
    }
}
