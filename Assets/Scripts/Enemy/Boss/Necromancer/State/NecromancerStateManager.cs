using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;
using Ndd.Stat;
public class NecromancerStateManager : StateManager , INecromancerStateManager
{
    readonly IState stateIdle;
    readonly IState stateAttack;
    readonly IState stateMove;
    readonly IState stateHealing;

    GameObject gameobjNecromancer;
    Necromancer necromancerScript;
    GameObject gameObjPlayer;
    ICooldownChecker cooldownChecker;
    IAnimEventSource animation;

    bool canChangeStatHeling = false;
    int healThreshold = 20;

    public IState StateIdle => stateIdle;
    public IState StateAttack => stateAttack;
    public IState StateMove => stateMove;
    public IState StateHealing => stateHealing;



    public NecromancerStateManager(Necromancer necromancerScript, GameObject gameObjectPlayer, IAnimEventSource animation) : base()
    {
        this.necromancerScript = necromancerScript;
        this.gameobjNecromancer = necromancerScript.gameObject;
        this.gameObjPlayer = gameObjectPlayer;
        this.animation = animation;

        stateIdle = new NecromancerStateIdle(this,this, animation);
        stateAttack = new NecromancerStateAttack(this,this, animation, necromancerScript.AttackData, necromancerScript.Bullets, BulletManager.instance.Pool);
        stateMove = new NecromancerStateMove(this,this, necromancerScript.Stat.GetStatValue(StatName.Speed));
        stateHealing = new NecromancerStateHealth(this,this, necromancerScript.Stat, necromancerScript.Collider, animation);
    }

    public override void Initialize()
    {
        base.Initialize();
        cooldownChecker = new CooldownChecker(necromancerScript.TimerAttack);
        ChangeState(stateIdle);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(stateCurrent.ToString());
        cooldownChecker.UpdateCooldown(Time.deltaTime);
    }

    public bool IsOutOfRange() {
        return Vector3.Distance(GetPosition(), gameObjPlayer.transform.position) > 4 ? true : false;
    }

    public Vector3 GetDirectionToPlayer() {
        return (gameObjPlayer.transform.position - GetPosition()).normalized;
    }

    public void SetPosition(Vector3 position) {
        gameobjNecromancer.transform.position = position;
    }

    public Vector3 GetPosition() {
        return gameobjNecromancer.transform.position;
    }

    public bool IsAttackReady() {
        return cooldownChecker.IsTimeout;
    }

    public void ResetCoolDownAttack() {
        cooldownChecker.ResetCooldown();
    }

    public bool IsBelowHealThreshold()
    {
        return necromancerScript.Stat.GetStatValue(StatName.Hp) / necromancerScript.Stat.GetStatValue(StatName.HpMax) == healThreshold && canChangeStatHeling;
    }

    public void DisableHealingTransition() { 
        canChangeStatHeling = false;
    }

    protected override void StateExitHandler(IState state)
    {
        if (state == this.stateAttack)
        {
            necromancerScript.StartReleaseOrb();
        }
    }

    
}