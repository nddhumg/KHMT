using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleLevel : Level
{
    [SerializeField] protected Rifle rifle;

    public override bool LevelUp()
    {
        if (!base.LevelUp())
            return false;

        switch (levelCurrent)
        {
            case 2:
                rifle.IncreaseAttackSpeed(0.3f); 
                break;

            case 3:
                rifle.IncreaseDamageMultiplier(0.5f); 
                rifle.IncreaseAmmoCapacity(2);
                break;

            case 4:
                rifle.IncreaseDamageMultiplier(0.5f);
                rifle.IncreaseAttackSpeed(0.3f);
                break;

            case 5:
                rifle.SetAttackSpeed(0);
                rifle.IncreaseDamageMultiplier(0.3f);
                break;
        }
        return true;
    }
}
