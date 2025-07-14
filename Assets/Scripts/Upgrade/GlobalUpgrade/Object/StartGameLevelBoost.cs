using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameLevelBoost : IUpgradeOnStart
{
    public void ApplyUpgrade()
    {
        Player.instance.Level.LevelUp();
    }

}
