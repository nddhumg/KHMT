using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunLevel : Level
{
    [SerializeField] protected ShotGun shotGun;
    private void Reset()
    {
        levelMax = 5;
    }

    public override bool LevelUp()
    {
        if (!base.LevelUp())
            return false;
        switch (LevelCurrent)
        {
            case 1:
                shotGun.IncreaseAttackSpeed(0.5f);
                break;
            case 2:
                shotGun.IncreaseDamageMultiplier(1);
                break;
        }
        return true;

    }
}
