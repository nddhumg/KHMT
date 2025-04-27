using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Inventory;

public class Player : Singleton<Player>
{
    PlayerStateMachine state;
    [SerializeField] Animator anim;
    Transform weapon;
    SpriteRenderer spriteWeapon;
    [SerializeField] private PlayerLevel level;
    [SerializeField] private PlayerStat statManager;
    [SerializeField] private PlayerSkill skillManager;

    [SerializeField] private GameObject healingEffect;
    [SerializeField] private Transform sprite;

    private Vector2 directionMove = Vector2.up;
    private int directionLook = 1;
    private Vector3 rotationWeapon = Vector3.zero;


    public PlayerLevel Level => level;
    public PlayerStat StatsManager => statManager;
    public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => directionMove;

    void Start()
    {
        state = new PlayerStateMachine(anim, this, statManager);
        state.Initialize();
        statManager.StatCurrent.OnChangeStat += CheckDead;
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

    public void SetWeapon(GameObject weapon)
    {
        this.weapon = weapon.transform;
        this.spriteWeapon = weapon.GetComponentInChildren<SpriteRenderer>();
    }

    public void Flip()
    {
        sprite.localScale = new Vector3(-1 * sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
    }

    public void ActiveEffectHealing()
    {
        healingEffect.SetActive(true);
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

    void CheckDead(EnumName.Stat stat, float value)
    {
        if (stat == EnumName.Stat.Hp && value <= 0)
        {
            ScreenGameOver.instance.Deffeat();
        }
    }
}
