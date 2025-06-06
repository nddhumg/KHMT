using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
namespace Core.Skill
{
    public class RadiantBlastLevel : Level
    {
        [SerializeField] protected RadiantBlast radiantBlast;

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
                case 1:
                    break;
                case 2:
                    radiantBlast.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    radiantBlast.IncreaseSkillRange(0.3f);
                    break;
                case 3:
                    radiantBlast.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    break;
                case 4:
                    radiantBlast.DamageComponent.IncreaseDamageMultiplier(0.5f);
                    radiantBlast.CoolDownComponent.IncreaseAttackSpeed(0.2f);
                    break;
                case 5:
                    radiantBlast.DamageComponent.IncreaseDamageMultiplier(1f);
                    break;
            }
            return true;
        }
    }
}