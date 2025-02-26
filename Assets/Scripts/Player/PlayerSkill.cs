using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSkill : MonoBehaviour
{
    Dictionary<EnumName.Skill, Level> skillLevel = new Dictionary<EnumName.Skill, Level>();
    Dictionary<string,GameObject> skillGameoObj = new Dictionary<string, GameObject>();
    public void Upgrade(EnumName.Skill skill,GameObject prefab)
    {
        if (skillLevel.ContainsKey(skill))
        {
            skillLevel[skill].LevelUp();
        }
        else {
            GameObject skillGO = Instantiate(prefab, transform);
            Level level = skillGO.GetComponentInChildren<Level>();
            skillLevel.Add(skill, level);
            skillGameoObj.Add(skill.ToString(), skillGO);
        }
    }

    public int GetLevelSkill(EnumName.Skill skill) {
        if (skillLevel.ContainsKey(skill))
        {
            return (int)skillLevel[skill].LevelCurrent;
        }
        else
            return 0;
    }

    public GameObject GetGameObj(string name) {
        return skillGameoObj[name];
    }
}
