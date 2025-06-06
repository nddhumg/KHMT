using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class RifleLevel : Level
    {
        [SerializeField] protected Rifle rifle;

        public override bool LevelUp()
        {
            if (!base.LevelUp())
                return false;

            switch (levelCurrent)
            {
                case 2:
                    rifle.CoolDownSkillComponent.IncreaseAttackSpeed(0.3f);
                    break;

                case 3:
                    rifle.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    rifle.IncreaseBulletCount(2);
                    break;

                case 4:
                    rifle.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    rifle.CoolDownSkillComponent.IncreaseAttackSpeed(0.3f);
                    break;

                case 5:
                    rifle.CoolDownSkillComponent.SetAttackSpeed(0.3f);
                    rifle.DamageComponent.IncreaseDamageMultiplier(0.3f);
                    break;
            }
            return true;
        }
    }
}