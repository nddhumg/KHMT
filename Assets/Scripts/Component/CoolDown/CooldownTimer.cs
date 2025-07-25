using System;
using UnityEngine;

namespace Ndd.Cooldown
{

    public class CooldownTimer : ICooldown
    {
        private float timer = 0;
        private float cooldown;
        private float timeScale = 1;
        private uint cooldownCount = 0;
        private bool isStart;
        private bool countUp;

        public float Cooldown { get => cooldown; set => cooldown = value; }
        public float Timer => timer;
        public float TimeScale
        {
            get => timeScale;
            set => timeScale = Mathf.Max(0.0001f, value);
        }
        public uint CooldownCount => cooldownCount;
        public bool IsStart => isStart;
        public bool CountUp => countUp;

        public CooldownTimer(float cooldown = 1f, float timeScale = 1, bool isStart = true, bool countUp = true)
        {
            this.cooldown = cooldown;
            this.timeScale = timeScale;
            this.isStart = isStart;
            this.countUp = countUp;

            if (!countUp) {
                timer = cooldown / timeScale;
            }
        }

        public virtual void UpdateCooldown(float elapsedTimeSeconds)
        {
            if (!isStart)
                return;
            if (IsCooldownActive())
            {
                if (countUp)
                {
                    timer += elapsedTimeSeconds;
                }
                else
                {
                    timer -= elapsedTimeSeconds;
                }
                return;
            }
            TriggerTimeout();
        }

        public virtual void ResetCooldown()
        {
            if (countUp)
            {
                timer = 0;
            }
            else
            {
                timer = cooldown / timeScale;
            }
        }

        protected virtual bool IsCooldownActive()
        {
            if (countUp)
            {
                return timer <= cooldown / timeScale;
            }
            else
            {
                return timer >= 0;
            }
        }

        protected virtual void TriggerTimeout()
        {
            ResetCooldown();
            cooldownCount++;
        }

        public void Start()
        {
            isStart = true;
        }

        public void Pause()
        {
            isStart = false;
        }
    }
}