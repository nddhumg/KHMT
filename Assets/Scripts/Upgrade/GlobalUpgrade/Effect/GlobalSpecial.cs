using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpecial : IGlobalUpgradeEffect
{
    protected Dictionary<string,IUpgradeOnStart> effectOnStart;
    protected IUpgradeOnStart upgradeOnStart;
    protected string name;

    public GlobalSpecial(Dictionary<string, IUpgradeOnStart> effectManager , IUpgradeOnStart upgrade,string name)
    {
        this.effectOnStart = effectManager;
        this.upgradeOnStart = upgrade;
        this.name = name;
    }

    public void ApplyEffect()
    {
        effectOnStart.Add(name,upgradeOnStart);
    }

    public void RevertEffect()
    {
        //TODO
    }
}
