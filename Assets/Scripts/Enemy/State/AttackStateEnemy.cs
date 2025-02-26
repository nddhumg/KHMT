using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy : EnemyState {
    protected EnemyArcStateManager rangedEnemyState;
	protected CoolDownTimer timer;
    protected
	bool isAttack = true;
    protected GameObject bullet;
    public AttackStateEnemy(EnemyArcStateManager enemyState, float attackCoolDown,GameObject bullet) : base(enemyState)
    {
		timer = new CoolDownTimer(attackCoolDown);
		timer.OnCoolDownEnd += Attack;
        this.bullet = bullet;
        rangedEnemyState = enemyState;
    }

    public override void Enter()
    {
        base.Enter();
		timer.ResetCoolDown();
        isAttack = true;
    }

    public override void CheckChangeState()
    {
        if (!rangedEnemyState.IsInAttackRange() && !isAttack)
        {
            enemyState.ChangeState(rangedEnemyState.moveState);
            return;
        }
    }

    public override void UpdateLogic ()
	{
		base.UpdateLogic ();
		timer.CountTime(Time.deltaTime);
	}

	protected virtual void Attack() { 
        MoveInDirection moveBullet = BulletPool.instance.Spawn(bullet, enemyState.GetPosition(), Quaternion.identity).GetComponentInChildren<MoveInDirection>();
        moveBullet.Direction = enemyState.GetDirecTionToPlayer();
        isAttack = false;
    }
}
