using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;
public class NecromancerStateIdle : IState
{
    protected StateManager stateManager;
    protected INecromancerStateManager necromancerState;
    protected IAnimEventSource animation;

    public NecromancerStateIdle(StateManager stateManager,INecromancerStateManager necromancerState, IAnimEventSource animtion)
    {
        this.necromancerState = necromancerState ;
        this.stateManager = stateManager;
        this.animation = animtion;
    }

    public void CheckChangeState()
    {
        if (necromancerState.IsBelowHealThreshold())
        {
            stateManager.ChangeState(necromancerState.StateHealing);
            necromancerState.DisableHealingTransition();
        }
        else if (necromancerState.IsAttackReady())
        {
            stateManager.ChangeState(necromancerState.StateAttack);
        }
        else if (necromancerState.IsOutOfRange())
        {
            stateManager.ChangeState(necromancerState.StateMove);
        }
    }

    public void Enter()
    {
        animation.Play(NecromancerAnimName.Idle.ToString());
    }

    public void Exit()
    {
    }

    public void UpdateLogic()
    {
        CheckChangeState();
    }

    public void UpdatePhysics()
    {
    }
}
