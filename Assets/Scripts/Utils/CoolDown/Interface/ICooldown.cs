using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Cooldown
{
    public interface ICooldown
    {
        public float TimeScale { get; set; }
        public float Cooldown { get; set; }

        public float Timer { get; }

        void UpdateCooldown(float elapsedTime);

        void ResetCooldown();

    }
}