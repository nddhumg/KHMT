using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSkill : MonoBehaviour
{
    Dictionary<EnumName.Skill, Level> skillLevel;

    public void Upgrade(EnumName.Skill skill,GameObject prefab)
    {
        if (skillLevel.ContainsKey(skill))
        {
            skillLevel[skill].LevelUp();
        }
        else {
            GameObject skillGO = Instantiate(prefab, Player.instance.transform);
            Level level = skillGO.GetComponentInChildren<Level>();
            skillLevel.Add(skill, level);   
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

}
