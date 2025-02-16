using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
	protected Vector2 attackDirection = Vector2.down;
	protected CoolDownTimer timer;
	[SerializeField] protected SOStat stats;

    private void Awake()
    {
		timer = new CoolDownTimer(stats.GetStatValue(EnumName.Stat.AttackRate));
		timer.OnCoolDownEnd += Attack;	
    }

	protected virtual void Start()
	{
		attackDirection = Vector2.down;
	}

    protected virtual void Update(){
		timer.CountTime(Time.deltaTime);
		if(JoyStick.instance.Direction != Vector2.zero)
			attackDirection = JoyStick.instance.Direction;
	}

	protected abstract void Attack();
		
}
