using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Inventory;
using Ndd.Stat;
using System;


public class Player : Singleton<Player>, IReceiveDamage
{
    PlayerStateMachine state;
    [SerializeField] Animator anim;
    Transform weapon;
    SpriteRenderer spriteWeapon;
    [SerializeField] private PlayerLevel level;
    [SerializeField] private PlayerSkill skillManager;
    [SerializeField] private PlayerEffect effect;
    private IStat statCurrent;

    [SerializeField] private Transform sprite;

    private Vector2 directionMove = Vector2.up;
    private int directionLook = 1;
    private Vector3 rotationWeapon = Vector3.zero;

    public Action OnPlayerDead;
    private bool canRevive;

    public PlayerEffect Effect => effect;
    public IStat StatCurrent => statCurrent;
    public PlayerLevel Level => level;
    public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => directionMove;
    public bool CanRevive { set { canRevive = value; } }

    void Start()
    {
        statCurrent = GameController.instance.StatPlayer.Clone();
        statCurrent.Stats.Add(new StatEntry(StatName.Hp, statCurrent.GetStatValue(StatName.HpMax)));
        state = new PlayerStateMachine(anim, this, statCurrent);
        state.Initialize();
        statCurrent.OnStatUpdatedValue += CheckDead;
    }

    void FixedUpdate()
    {
        state.FixedUpdate();
    }

    void Update()
    {
        
        state.Update();
        if (JoyStick.instance.Direction != Vector2.zero)
            directionMove = JoyStick.instance.Direction;
        if (JoyStick.instance.Direction.x > 0)
        {
            if (directionLook != 1)
            {
                directionLook = 1;
                Flip();
            }
        }
        else if (JoyStick.instance.Direction.x < 0)
        {
            if (directionLook != -1)
            {
                directionLook = -1;
                Flip();
            }
        }
        RotateWeapon();
    }

    public void TakeDamage(int damage)
    {
        statCurrent.IncreaseStat(StatName.Hp, -damage);
        effect.ActiveEffectTakeDamage();
    }

    public void SetWeapon(GameObject weapon)
    {
        this.weapon = weapon.transform;
        this.spriteWeapon = weapon.GetComponentInChildren<SpriteRenderer>();
    }

    public void Revive() { 
        statCurrent.SetStatValue(StatName.Hp, statCurrent.GetStatValue(StatName.HpMax));

    }

    public void Flip()
    {
        sprite.localScale = new Vector3(-1 * sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
    }


    void RotateWeapon()
    {
        if (weapon == null)
            return;
        rotationWeapon.z = Vector2.Angle(Vector2.right, directionMove);
        rotationWeapon.z *= directionMove.y < 0 ? -1 : 1;
        if (directionMove.x < 0)
            spriteWeapon.flipY = true;
        else
            spriteWeapon.flipY = false;
        weapon.eulerAngles = rotationWeapon;
    }

    void CheckDead(StatName stat, float value)
    {
        if (stat == StatName.Hp && value <= 0)
        {
            if (canRevive) { 
                Revive();
                return;
            }
            OnPlayerDead?.Invoke();
        }
    }

    
}
