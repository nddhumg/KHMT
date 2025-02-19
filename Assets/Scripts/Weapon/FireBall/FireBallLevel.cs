using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallLevel : Level
{
    [SerializeField] protected FireBall fireBall;
    private void Reset()
    {
        levelMax = 5;
    }

    public override bool LevelUp()
    {
        if(! base.LevelUp())
            return false;
        switch (levelCurrent) {
            case 2:
                fireBall.IncreaseDamageMultiplier(0.5f);
                break;
            case 3:
                fireBall.IncreasePrerFire(1);
                break;
            case 4:
                fireBall.IncreaseAttackSpeed(0.5f);
                break;
            case 5:
                fireBall.IncreasePrerFire(1);
                fireBall.IncreaseDamageMultiplier(1f);
                fireBall.IncreaseAttackSpeed(0.5f);
                break;


        }
        return true;
    }
}
