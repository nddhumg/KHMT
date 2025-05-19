using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatBonusByLevelPlayer
{
    protected float growthRateHp = 0.2f;
    protected float growthRateDamage = 0.15f;
    protected PlayerLevel level;

    public EnemyStatBonusByLevelPlayer(PlayerLevel playerLevel){
        this.level = playerLevel;
    }

    public int GetBonusHp()
    {
         return (int)(1 +  growthRateHp * (int)level.LevelCurrent);
    }

    public int GetBonusDamage()
    {
        return (int)(1 + growthRateHp * (int)level.LevelCurrent);
    }
}
