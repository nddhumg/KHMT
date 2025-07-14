using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;
using System;


public class PlayerSkill : MonoBehaviour
{
    Dictionary<Skill, Level> skillLevel = new Dictionary<Skill, Level>();
    Dictionary<string, GameObject> skillGameoObj = new Dictionary<string, GameObject>();

    [SerializeField] private int maxSkill = 6;
    public Action<SOUpgrade> OnUpgradeApplied;

    public bool CanAddSkill => skillLevel.Count < maxSkill;

    public void Upgrade(Skill skill, GameObject prefab,SOUpgrade uiData )
    {
        if (IsSkillUnlocked(skill))
        {
            skillLevel[skill].LevelUp();
        }
        else
        {
            GameObject skillGO = Instantiate(prefab, transform);
            Level level = skillGO.GetComponentInChildren<Level>();
            skillLevel.Add(skill, level);
            skillGameoObj.Add(skill.ToString(), skillGO);
            level.LevelUp();
            OnUpgradeApplied?.Invoke(uiData);
        }
    }

    public int GetLevelSkill(Skill skill)
    {
        return (int)(GetLevelByName(skill)?.LevelCurrent ?? 0);
    }

    public bool CanLevelUp(Skill skill)
    {
        return GetLevelByName(skill).CanLevelUp();
    }

    public GameObject GetGameObj(string name)
    {
        return skillGameoObj[name];
    }

    private Level GetLevelByName(Skill skill)
    {
        if (skillLevel.ContainsKey(skill))
        {
            return skillLevel[skill];
        }
        else
        {
            return null;
        }
    }

    private bool IsSkillUnlocked(Skill skill)
    {
        return skillLevel.ContainsKey(skill);
    }
}
