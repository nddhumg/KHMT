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

        public float Cooldown { get => cooldown; set => cooldown = value; }
        public float Timer => timer;
        public float TimeScale
        {
            get => timeScale;
            set => timeScale = Mathf.Max(0.0001f, value);
        }

        public uint CooldownCount => cooldownCount;

        public bool IsStart => isStart;

        public CooldownTimer(float cooldown = 1f, float timeScale = 1, bool isStart = true)
        {
            this.cooldown = cooldown;
            this.timeScale = timeScale;
            this.isStart = isStart;
        }

        public virtual void UpdateCooldown(float elapsedTimeSeconds)
        {
            if (!isStart)
                return;
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