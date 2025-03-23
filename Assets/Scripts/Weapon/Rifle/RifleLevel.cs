using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleLevel : Level
{
    [SerializeField] protected Rifle rifle;

    public override bool LevelUp()
    {
        if (!base.LevelUp())
            return false;

        switch (levelCurrent)
        {
            case 0:

                break;
        }
        return true;
    }
}
