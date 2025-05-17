using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
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
                    shotGun.CoolDownSkillComponent.IncreaseAttackSpeed(0.5f);
                    break;

                case 3:
                    shotGun.DamageComponent.IncreaseDamageMultiplier(1);
                    break;

                case 4:
                    shotGun.IncreaseBulletCount(2);
                    break;

                case 5:
                    shotGun.CoolDownSkillComponent.IncreaseAttackSpeed(0.3f);
                    shotGun.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    shotGun.IncreaseBulletCount(1);
                    break;

            }
            return true;

        }
    }

}