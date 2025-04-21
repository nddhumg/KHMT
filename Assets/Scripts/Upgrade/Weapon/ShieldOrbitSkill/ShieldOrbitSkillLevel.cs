using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOrbitSkillLevel : Level
{
    [SerializeField] protected ShieldOrbitSkill orbital;
    public override bool LevelUp()
    {
        if (base.LevelUp()) {
            switch (levelCurrent)
            {
                case 2:
                    orbital.SpawnShield(); 
                   orbital.IncreaseRotationSpeed(20f); 
                    break;

                case 3:
                    orbital.SetDamageMultiplier(1.5f); 
                    break;

                case 4:
                    orbital.SpawnShield(); 
                    break;

                case 5:
                    orbital.IncreaseRotationSpeed(10f);
                    orbital.SetDamageMultiplier(1.3f);
                    orbital.SpawnShield(); 
                    break;

            }
            return true;
        }
        return false;
    }
}
