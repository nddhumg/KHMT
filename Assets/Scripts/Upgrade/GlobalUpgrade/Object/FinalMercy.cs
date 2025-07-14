using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMercy : IUpgradeOnStart
{
    public void ApplyUpgrade()
    {
        Player.instance.CanRevive = true;
    }

}
