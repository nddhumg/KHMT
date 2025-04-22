using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class PistolLevel : Level
    {
        [SerializeField] protected Pistol pistol;

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
                    pistol.CoolDownSkillComponent.IncreaseAttackSpeed(0.5f);
                    break;
                case 3:
                    pistol.DamageComponent.IncreaseDamageMultiplier(1);
                    break;
                case 4:
                    pistol.CoolDownSkillComponent.IncreaseAttackSpeed(0.3f);
                    pistol.DamageComponent.IncreaseDamageMultiplier(1f);
                    break;

                case 5:
                    pistol.CoolDownSkillComponent.IncreaseAttackSpeed(2f);
                    pistol.DamageComponent.IncreaseDamageMultiplier(1f);
                    break;
            }
            return true;

        }
    }
}
