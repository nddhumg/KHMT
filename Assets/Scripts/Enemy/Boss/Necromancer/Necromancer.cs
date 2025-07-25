using Core.Enemies;
using Ndd.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;

public class Necromancer : Boss
{
    [SerializeField] protected NecromancerStateAttackData attackData;
    protected Stack<NercromancerBullet> bullets = new();
    protected ICoolDownAuto orbReleaseCooldown;

    [SerializeField] protected float timerAttack = 1;

    private NecromancerStateManager stateManager;
    [SerializeField] protected NecromancerAnimatorCtrl animatorCtrl;
    [SerializeField] protected BoxCollider2D boxCollider;


    public NecromancerStateAttackData AttackData => attackData;
    public float TimerAttack => timerAttack;
    public Stack<NercromancerBullet> Bullets => bullets;
    public NecromancerAnimatorCtrl AnimatorCtrl => animatorCtrl;
    public Collider2D Collider => boxCollider;


    protected override void Start()
    {
        base.Start();
        stateManager = new NecromancerStateManager(this, Player.instance.gameObject, animatorCtrl);
        stateManager.Initialize();
        orbReleaseCooldown = new AutoCooldownTimer(0.5f);
        orbReleaseCooldown.AddTimeoutListener(ReleaseOrb);
        orbReleaseCooldown.Pause();
    }

    private void Update()
    {
        transform.position = Vector3.zero;
        stateManager.Update();
        orbReleaseCooldown.UpdateCooldown(Time.deltaTime);
    }

    public void StartReleaseOrb() { 
        orbReleaseCooldown.Start();
    }


    private void FixedUpdate()
    {
        stateManager.FixedUpdate();
    }

    protected void ReleaseOrb() {
        bullets.Pop().MoveToPlayer() ;
        if (bullets.Count == 0)
            orbReleaseCooldown.Pause();
    }

}
