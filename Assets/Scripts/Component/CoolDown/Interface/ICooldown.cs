using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Cooldown
{
    public interface ICooldown
    {
        public uint CooldownCount { get; }
        public float TimeScale { get; set; }
        public float Cooldown { get; set; }
        public float Timer { get; }
        public bool IsStart { get; }

        void Start();

        void Pause();

        void UpdateCooldown(float elapsedTime);

        void ResetCooldown();

    }
}