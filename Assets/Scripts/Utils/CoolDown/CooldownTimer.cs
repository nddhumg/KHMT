using System;
using UnityEngine;

namespace Ndd.Cooldown
{

    public class CooldownTimer : ICooldown
    {
        private float timer = 0;
        private float cooldown;
        private float timeScale = 1;

        public float Cooldown { get => cooldown; set => cooldown = value; }
        public float Timer => timer;
        public float TimeScale
        {
            get => timeScale;
            set => timeScale = Mathf.Max(0.0001f, value);
        }

        public CooldownTimer(float cooldown = 1f, float timeScale = 1)
        {
            this.cooldown = cooldown;
            this.timeScale = timeScale;
        }

        public virtual void UpdateCooldown(float elapsedTimeSeconds)
        {
            if (IsCooldownActive())
            {
                timer += elapsedTimeSeconds;
                return;
            }
            TriggerTimeout();
        }

        public virtual void ResetCooldown()
        {
            timer = 0;
        }

        protected virtual bool IsCooldownActive()
        {
            return timer <= cooldown / timeScale;
        }

        protected virtual void TriggerTimeout()
        {
            ResetCooldown();
        }
    }
}