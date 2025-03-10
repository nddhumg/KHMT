using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbitSkillLevel : Level
{
    [SerializeField] protected ShieldOrbitSkill shieldOrbit;
    public override bool LevelUp()
    {
        if (base.LevelUp()) {
            //switch (levelCurrent)
            //{
            //    case
            //}
            return true;
        }
        return false;
    }
}
