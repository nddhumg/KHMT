using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Inventory;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    PlayerStateMachine state;
    [SerializeField] Animator anim;
    Transform weapon;
    [SerializeField] private PlayerLevel level;
    [SerializeField] private PlayerStat statManager;
    [SerializeField] private PlayerSkill skillManager;

    [SerializeField] private GameObject healingEffect;
    [SerializeField] private Transform sprite;
    
    private Vector2 directionMove = Vector2.up;
    private int directionLook = 1;
    private Vector3 rotationWeapon = Vector3.zero;
    
    private InputAction moveAction;
    private PlayerInput playerInput;


    public PlayerLevel Level => level;
    public PlayerStat StatsManager => statManager;
    public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => directionMove;

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.enabled = true;

    }

    private void OnDisable()
    {
        playerInput.enabled = false;
    }

    void Start()
    {
        state = new PlayerStateMachine(anim, this, statManager);
        state.Initialize();
        weapon = skillManager.GetGameObj(InventoryManager.instance.EquippedWeapon.nameItem.ToString()).transform;
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
        rotationWeapon = transform.localRotation.eulerAngles;
        rotationWeapon.z = Vector2.Angle(Vector2.right, directionMove);
        rotationWeapon.z *= directionMove.y < 0 ? -1 : 1;

        weapon.localRotation = Quaternion.Euler(rotationWeapon);
    }

    void CheckDead(EnumName.Stat stat ,float value) { 
        if(stat == EnumName.Stat.Hp && value <= 0)
        {
            ScreenGameOver.instance.Deffeat();
        }
    }
}
