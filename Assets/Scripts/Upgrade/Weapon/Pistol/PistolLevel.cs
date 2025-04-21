using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolLevel : Level
{
    [SerializeField] protected Pistol pistol;

    private void Reset()
    {
        levelMax = 5;
    }

    public override bool LevelUp()
    {
        if (!base.LevelUp())
            return false;
        switch (LevelCurrent) {
            case 2:
                pistol.IncreaseAttackSpeed(0.5f);
                break;
            case 3:
                pistol.IncreaseDamageMultiplier(1);
                break;
            case 4:
                pistol.IncreaseAttackSpeed(0.3f);
                pistol.IncreaseDamageMultiplier(1f);
                break;

            case 5:
                pistol.IncreaseAttackSpeed(2f); 
                pistol.IncreaseDamageMultiplier(1f);
                break;
        }
        return true;

    }
}
