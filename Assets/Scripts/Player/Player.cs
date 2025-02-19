using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	PlayerStateMachine state;
	[SerializeField] Animator anim;
	[SerializeField] Transform spriteTf;
	[SerializeField] Transform weapon;
	[SerializeField] private PlayerLevel level;
	[SerializeField] private PlayerStat statManager;
	[SerializeField] private PlayerSkill skillManager;
	private Vector2 directionMove = Vector2.up;
	private int directionLook = 1;
	private Vector3 rotationWeapon = Vector3.zero;
	

	public PlayerLevel Level => level;
	public PlayerStat StatsManager => statManager;
	public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => directionMove;

	public void Flip() {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void Start() {
		state = new PlayerStateMachine(anim, this, statManager);
		state.Initialize();
	}

	void Update() {
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

    void RotateWeapon() {
        rotationWeapon = transform.localRotation.eulerAngles;
        if (directionLook == 1)
        {
            rotationWeapon.z = Vector2.Angle(Vector2.right, directionMove);
        }
        else
        {
            rotationWeapon.z = Vector2.Angle(Vector2.left, directionMove);
        }
        if(directionMove.y < 0)
            rotationWeapon.z *= -1;

        weapon.localRotation = Quaternion.Euler(rotationWeapon);
    }

	void FixedUpdate() {
		state.FixedUpdate();
	}

	void OnTriggerEnter2D(Collider2D col) {
		PickUp(col.gameObject);
	}

	void PickUp(GameObject item) {
        IItemPickUp itemScript = item.GetComponent<IItemPickUp>();
        if (itemScript != null)
            itemScript.PickUpAble();
    }


}
