using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Cooldown
{
    public class CooldownChecker : CooldownTimer, ICooldownChecker
    {
        private bool isTimeout;

        public bool IsTimeout => isTimeout;

        public CooldownChecker(float cooldown = 1f, float timeScale = 1, bool isStart = true, bool countUp = true) : base(cooldown, timeScale, isStart, countUp)
        {
        }

        public override void ResetCooldown()
        {
            base.ResetCooldown();
            isTimeout = false;
        }

        protected override void TriggerTimeout()
        {
            isTimeout = true;
        }

        

    }
}
