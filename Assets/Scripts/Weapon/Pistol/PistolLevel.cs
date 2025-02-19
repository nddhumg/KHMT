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
            case 1:
                pistol.IncreaseAttackSpeed(0.5f);
                break;
            case 2:
                pistol.IncreaseDamageMultiplier(1);
                break;
        }
        return true;

    }
}
