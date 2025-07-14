using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Cooldown
{
    public interface ICoolDownAuto : ICooldown
    {
        void AddTimeoutListener(Action action);

        void RemoveTimeoutListener(Action action);

        void ClearTimeoutListeners();
    }

}