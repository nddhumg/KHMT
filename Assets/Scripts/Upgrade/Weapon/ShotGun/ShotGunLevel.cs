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
            case 2:
                shotGun.IncreaseAttackSpeed(0.5f); 
                break;

            case 3:
                shotGun.IncreaseDamageMultiplier(1); 
                break;

            case 4:
                shotGun.IncreasePelletCount((uint)2);
                break;

            case 5:
                shotGun.IncreaseAttackSpeed(0.3f);
                shotGun.IncreaseDamageMultiplier(0.5f);
                shotGun.IncreasePelletCount(1); 
                break;

        }
        return true;

    }
}
