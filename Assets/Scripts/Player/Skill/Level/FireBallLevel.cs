using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class FireBallLevel : Level
    {
        [SerializeField] protected FireBall fireBall;
        private void Reset()
        {
            levelMax = 5;
        }

        public override bool LevelUp()
        {
            if (!base.LevelUp())
                return false;
            switch (levelCurrent)
            {
                case 2:
                    fireBall.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    return true;
                case 3:
                    fireBall.IncreaseBulletCount(1);
                    return true;
                case 4:
                    fireBall.CoolDownSkillComponent.IncreaseAttackSpeed(0.5f);
                    return true;
                case 5:
                    fireBall.IncreaseBulletCount(1);
                    fireBall.DamageComponent.IncreaseDamageMultiplier(1f);
                    fireBall.CoolDownSkillComponent.IncreaseAttackSpeed(0.5f);
                    return true;


            }
            return false;
        }
    }
}
