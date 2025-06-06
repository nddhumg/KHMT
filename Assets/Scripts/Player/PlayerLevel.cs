using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : Level
{
    [SerializeField] protected uint exp = 0;
    protected uint expLevelUp = 10;
    [SerializeField] protected uint expMultiplier = 10;


    public uint Exp => exp;
    public uint ExpLevelUp => expLevelUp;

    private void Start()
    {
        IncreaseExpForLevelUp();
    }


    public void ExpUp(uint expUp)
    {
        this.exp += expUp;
        if (this.exp >= expLevelUp)
        {
            LevelUp();
            exp = 0;
        }
    }

    [Button]
    public override bool LevelUp()
    {
        if (base.LevelUp())
        {
            IncreaseExpForLevelUp();
            UpgradeSystem.instance.CreateUpgrade();
            return true;
        }
        return false;
    }

    protected void IncreaseExpForLevelUp()
    {
        expLevelUp = expMultiplier * levelCurrent;
    }
}
