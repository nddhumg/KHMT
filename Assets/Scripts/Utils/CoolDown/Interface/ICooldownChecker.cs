using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface ICooldownChecker : ICooldown
{
    public bool IsTimeout { get; }
}
