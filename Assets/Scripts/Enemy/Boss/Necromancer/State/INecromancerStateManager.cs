using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INecromancerStateManager
{
    IState StateIdle { get; }
    IState StateAttack { get; }
    IState StateMove { get; }
    IState StateHealing { get; }

    public bool IsOutOfRange();

    public Vector3 GetDirectionToPlayer();

    public void SetPosition(Vector3 position);

    public Vector3 GetPosition();

    public bool IsAttackReady();

    public void ResetCoolDownAttack();

    public bool IsBelowHealThreshold();

    public void DisableHealingTransition();
}
