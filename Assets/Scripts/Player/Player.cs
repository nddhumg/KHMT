using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    PlayerStateMachine state;
    [SerializeField] Animator anim;
    [SerializeField] Transform weapon;
    [SerializeField] private PlayerLevel level;
    [SerializeField] private PlayerStat statManager;
    [SerializeField] private PlayerSkill skillManager;

    [SerializeField] private GameObject healingEffect;
    private Vector2 directionMove = Vector2.up;
    private int directionLook = 1;
    private Vector3 rotationWeapon = Vector3.zero;


    public PlayerLevel Level => level;
    public PlayerStat StatsManager => statManager;
    public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => directionMove;

    public void SetWeapon(Transform weapon)
    {
        this.weapon = weapon;
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void ActiveEffectHealing()
    {
        healingEffect.SetActive(true);
    }
    void Start()
    {
        state = new PlayerStateMachine(anim, this, statManager);
        state.Initialize();
        weapon = skillManager.GetGameObj(Inventory.instance.EquippedWeapon.nameItem.ToString()).transform;
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

    void RotateWeapon()
    {
        rotationWeapon = transform.localRotation.eulerAngles;
        if (directionLook == 1)
        {
            rotationWeapon.z = Vector2.Angle(Vector2.right, directionMove);
        }
        else
        {
            rotationWeapon.z = Vector2.Angle(Vector2.left, directionMove);
        }
        if (directionMove.y < 0)
            rotationWeapon.z *= -1;

        //weapon.localRotation = Quaternion.Euler(rotationWeapon);
    }

}
