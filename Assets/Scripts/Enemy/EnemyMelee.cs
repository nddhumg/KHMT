using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    protected int damageCollsion =1;
    protected CoolDownTimer timer;
    [SerializeField] protected float attackCoolDown = 0.3f;
    private void Awake()
    {
        state = new EnemyMeleeStateManager(this,stat);
        timer = new CoolDownTimer(attackCoolDown, false);
        damageCollsion = (int)stat.GetStatValue(EnumName.Stat.Damage);
    }

    protected override void Update()
    {
        base.Update();
        timer.CountTime(Time.deltaTime);
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
