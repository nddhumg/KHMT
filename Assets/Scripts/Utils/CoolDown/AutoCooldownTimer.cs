using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Cooldown
{
    /// <summary>
    /// AutoCooldownTimer is a timer that automatically triggers an event when the cooldown expires.
    /// </summary>
    /// <remarks>
    /// This class extends CooldownTimer and implements ICoolDownAuto to provide automatic timeout handling.
    /// </remarks>
    /// <seealso cref="CooldownTimer"/>
    /// <seealso cref="ICoolDownAuto"/>
    /// </remarks>
    public class AutoCooldownTimer : CooldownTimer, ICoolDownAuto
    {
        public Action OnTimeout;

        public AutoCooldownTimer(float cooldown = 1f, float timeScale = 1,Action action = null) : base(cooldown, timeScale)
        {
            this.OnTimeout = action;
        }

        public void AddTimeoutListener(Action action)
        {
            OnTimeout += action;
        }

        public void ClearTimeoutListeners()
        {
            OnTimeout = null;
        }

        public void RemoveTimeoutListener(Action action)
        {
            OnTimeout -= action;
        }

        protected override void TriggerTimeout()
        {
            base.TriggerTimeout();
            OnTimeout?.Invoke();
        }
    }
}
