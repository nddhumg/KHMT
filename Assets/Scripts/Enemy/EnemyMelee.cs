using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    protected int damageCollsion =1;
    protected CoolDownTimer timer;
    protected float attackCoolDown = 0.3f;
    

    protected override void Update()
    {
        base.Update();
        timer.CountTime(Time.deltaTime);
    }

    public override void Init()
    {
        base.Init();
        damageCollsion = (int)statBase.GetStatValue(EnumName.Stat.Damage) * EnemySpawn.instance.Stat.GetBonusDamage();
        attackCoolDown = statBase.GetStatValue(EnumName.Stat.AttackRate);
        timer = new CoolDownTimer(attackCoolDown,false);
    }

    protected override void CreateStateManager()
    {
        state = new EnemyMeleeStateManager(this, statBase);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player") || !timer.IsCoolDownOver)
            return;
        IReceiveDamage receiver = collision.gameObject.GetComponentInChildren<IReceiveDamage>();
        if (receiver != null) {
            receiver.TakeDamage(damageCollsion);
            timer.ResetCoolDown();
        }

    }
}
