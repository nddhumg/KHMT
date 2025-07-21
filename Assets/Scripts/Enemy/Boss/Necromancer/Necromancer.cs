using Core.Enemies;
using Ndd.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;

public class Necromancer : MonoBehaviour, IReceiveDamage
{
    [SerializeField] protected NecromancerStateAttackData attackData;
    protected Stack<NercromancerBullet> bullets = new();
    protected ICoolDownAuto orbReleaseCooldown;

    [SerializeField] protected float timerAttack = 1;

    private NecromancerStateManager stateManager;
    [SerializeField] protected NecromancerAnimatorCtrl animatorCtrl;
    [SerializeField] protected BoxCollider2D boxCollider;

    [SerializeField] protected SOStat stat;


    public NecromancerStateAttackData AttackData => attackData;
    public float TimerAttack => timerAttack;
    public Stack<NercromancerBullet> Bullets => bullets;
    public NecromancerAnimatorCtrl AnimatorCtrl => animatorCtrl;
    public IStat Stat => stat;
    public Collider2D Collider => boxCollider;


    private void Start()
    {
        stat = stat.Clone();
        stat.AddStatValue(StatName.Hp, stat.GetStatValue(StatName.HpMax));
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

    public void TakeDamage(int damage)
    {
        EffectManager.instance.Pool.Take(EffectManager.instance.PopupDamage, transform.position, Quaternion.identity).GetComponent<PopupDamage>().SetText(damage);
        stat.IncreaseStat(StatName.Hp, -damage);
    }
}
