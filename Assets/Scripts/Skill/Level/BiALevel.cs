using Core.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill
{
    public class BiALevel : Level
    {
        [SerializeField] private BiA biA;

        private void Reset()
        {
            levelMax = 5;
        }

        public override bool LevelUp()
        {
            if (base.LevelUp())
                return false;
            switch (LevelCurrent) {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
            }
            return false;

        }
    }
}
