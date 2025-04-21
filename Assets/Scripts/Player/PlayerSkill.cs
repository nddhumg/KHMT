using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumName;


public class PlayerSkill : MonoBehaviour
{
    Dictionary<Skill, Level> skillLevel = new Dictionary<Skill, Level>();
    Dictionary<string, GameObject> skillGameoObj = new Dictionary<string, GameObject>();
    public void Upgrade(Skill skill, GameObject prefab)
    {
        if (skillLevel.ContainsKey(skill))
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
        }
    }

    public int GetLevelSkill(Skill skill)
    {
        return (int)(GetLevelByName(skill)?.LevelCurrent ?? 0);
    }

    public bool GetCanLevelUp(Skill skill)
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
}
