using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMeleeStateManager : IEnemyStateManager
{
     IState MoveState { get; }
}
