using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerStateMove : IState
{
    protected StateManager stateManager;
    protected INecromancerStateManager necromancerState;
    protected float speed;
    protected Vector3 positionNew;

    public NecromancerStateMove(NecromancerStateManager stateManager,INecromancerStateManager necromancerState, float speed)
    {
        this.necromancerState = stateManager;
        this.stateManager = stateManager;
        this.speed = speed;
    }

    public void CheckChangeState()
    {
        if (!necromancerState.IsOutOfRange()) {
            stateManager.ChangeState(necromancerState.StateIdle);
        }
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void UpdateLogic()
    {
        CheckChangeState();
        positionNew = necromancerState.GetPosition();
        positionNew +=  speed * Time.deltaTime * necromancerState.GetDirectionToPlayer();
        necromancerState.SetPosition(positionNew);
    }

    public void UpdatePhysics()
    {
    }

}
