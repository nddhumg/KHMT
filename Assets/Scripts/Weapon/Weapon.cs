using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
	protected CoolDownTimer timer;
	[SerializeField] protected float attackSpeed;
	[SerializeField] protected float damageMultiplier = 1;
	[SerializeField] protected GameObject bullet;
	[SerializeField] protected Transform muzzle;
	protected SOStat statPlayer;

    private void Awake()
    {
		timer = new CoolDownTimer(attackSpeed);
		timer.OnCoolDownEnd += Attack;	
    }

    private void Start()
    {
		statPlayer = Player.instance.StatsManager.StatCurrent;
    }

    protected virtual void Update(){
		timer.CountTime(Time.deltaTime);
	}

	public virtual void IncreaseDamageMultiplier(float value) {
		damageMultiplier += value;
	}
    public virtual void IncreaseAttackSpeed(float value)
    {
        attackSpeed -= value;
    }

    protected virtual Vector2 GetAttackDirection()
	{
        return Player.instance.Direction;
    }

	protected virtual int GetDamge() { 
		return (int)(statPlayer.GetStatValue(EnumName.Stat.Damage) * damageMultiplier);
	}

	protected abstract void Attack();
		
}
