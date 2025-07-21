using Ndd.Pool;
using Ndd.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerStateAttack : IState
{
    protected StateManager stateManager;
    protected INecromancerStateManager necromancerState;
    protected IAnimEventSource animation;

    protected float angleStep = 0;
    protected NecromancerStateAttackData dataAttack;
    protected Stack<NercromancerBullet> bullets;
    protected int damage;

    protected IPoolObject<GameObject, GameObject> poolBullet;

    public NecromancerStateAttack(StateManager stateManager, INecromancerStateManager necromancerState, IAnimEventSource animation , NecromancerStateAttackData data , Stack<NercromancerBullet> bullets, IPoolObject<GameObject,GameObject> pool, int damage)
    {
        this.necromancerState = necromancerState;
        this.stateManager = stateManager;
        this.dataAttack = data;
        this.animation = animation;
        this.poolBullet = pool;
        this.bullets = bullets;
        this.damage = damage;
    }

    public void CheckChangeState()
    {
    }

    public void Enter()
    {
        animation.EventAnim += HandleAnimation;
        animation.Play(NecromancerAnimName.Attack1.ToString());
        angleStep = 360f / dataAttack.countBullet;
    }

    public void Exit()
    {
        necromancerState.ResetCoolDownAttack();
        stateManager.OnExitState?.Invoke(this);
        animation.EventAnim -= HandleAnimation;
    }

    public void UpdateLogic()
    {
        CheckChangeState();
    }

    public void UpdatePhysics()
    {
    }

    protected void Attack()
    {
        Vector3 positionSpawnBullet = dataAttack.spawnCenter;
        positionSpawnBullet.y += dataAttack.spawnRadius;
        float angleCurrent = 0;
        for (int i = 0; i < dataAttack.countBullet; i++)
        {
            GameObject bulletNew = poolBullet.Take(dataAttack.bullet, positionSpawnBullet, Quaternion.identity);
            bulletNew.transform.SetParent(dataAttack.holderBullet);
            NercromancerBullet bulletScript = bulletNew.GetComponent<NercromancerBullet>();
            bulletScript.DamageSender.SetDamage(damage);
            bullets.Push(bulletNew.GetComponent<NercromancerBullet>());
            angleCurrent += angleStep;
            positionSpawnBullet.x = dataAttack.spawnCenter.x + Mathf.Sin(angleCurrent * Mathf.Deg2Rad) * dataAttack.spawnRadius;
            positionSpawnBullet.y = dataAttack.spawnCenter.y + Mathf.Cos(angleCurrent * Mathf.Deg2Rad) * dataAttack.spawnRadius;
        }
    }

    private void HandleAnimation(string nameEvent) {
        if (nameEvent == NecromancerAnimEventName.AttackHit.ToString())
        {
            Attack();

        }
        else if (nameEvent == NecromancerAnimEventName.Finish.ToString()) {
            stateManager.ChangeState(necromancerState.StateIdle);
        }

    }
}
