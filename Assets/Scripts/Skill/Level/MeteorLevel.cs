using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill {
    public class MeteorLevel : Level
    {
        [SerializeField] protected Meteor meteor;

        public override bool LevelUp()
        {
            if (!base.LevelUp())
                return false;
            switch (levelCurrent) {
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
