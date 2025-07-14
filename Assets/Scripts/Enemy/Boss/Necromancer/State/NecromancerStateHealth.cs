using Ndd.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;

public class NecromancerStateHealth : IState
{
    protected StateManager stateManager;
    protected INecromancerStateManager necromancerState;
    protected IAnimEventSource animation;
    protected IStat stat;
    protected float percentagehp = 10;
    protected int hpCount = 6;
    protected Collider2D col;
    protected ICoolDownAuto coolDownAuto;
   

    public NecromancerStateHealth(StateManager stateManager, INecromancerStateManager necromancerState, IStat stat, Collider2D collider, IAnimEventSource animation)
    {
        this.stateManager = stateManager;
        this.necromancerState = necromancerState;
        this.stat = stat;
        this.col = collider;
        this.animation = animation;
        coolDownAuto = new AutoCooldownTimer(0.3f, isStart:false);
        coolDownAuto.AddTimeoutListener(Health);

    }

    public void CheckChangeState()
    {
        if (coolDownAuto.CooldownCount == hpCount) {
            stateManager.ChangeState(necromancerState.StateIdle);   
        }
    }

    public void Enter()
    {
        animation.Play(NecromancerAnimName.Health.ToString());
        animation.EventAnim += HandleAnimation;
        col.enabled = false;
    }

    public void Exit()
    {
        col.enabled = true;
    }

    public void UpdateLogic()
    {
        CheckChangeState();
        coolDownAuto.UpdateCooldown(Time.deltaTime);

    }

    public void UpdatePhysics()
    {
    }

    private void Health() {
        stat.PercentageIncreaseStat(StatName.Hp, percentagehp);
    }

    private void HandleAnimation(string nameEvent) {
        if (nameEvent == NecromancerAnimEventName.Finish.ToString()) {
            coolDownAuto.Start();
            animation.Play(NecromancerAnimName.Idle.ToString());
        }
    }
}
