using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyArcStateManager : IEnemyStateManager
{
    IState AttackState{ get; }
    IState MoveState { get; }
    public bool IsInAttackRange();
}
