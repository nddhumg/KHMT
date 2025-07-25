using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbitSkillLevel : Level
{
    [SerializeField] protected ShieldOrbitSkill orbital;
    public override bool LevelUp()
    {
        if (!base.LevelUp())
        {
            return false;
        }
        switch (levelCurrent)
        {
            case 2:
                orbital.SpawnShield();
                orbital.IncreaseRotationSpeed(20f);
                return true;

            case 3:
                orbital.SetDamageMultiplier(1.5f);
                return true;

            case 4:
                orbital.SpawnShield();
                return true;

            case 5:
                orbital.IncreaseRotationSpeed(10f);
                orbital.SetDamageMultiplier(1.3f);
                orbital.SpawnShield();
                return true;

        }
        levelCurrent--;
        return false;
    }
}

