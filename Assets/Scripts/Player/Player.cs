using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	PlayerStateMachine state;
	[SerializeField]Animator anim;
	[SerializeField] private PlayerLevel level;
	[SerializeField] private PlayerStat statManager;
	[SerializeField] private PlayerSkill skillManager;
	protected Vector2 direction = Vector2.up;
	

	public PlayerLevel Level => level;
	public PlayerStat StatsManager => statManager;
	public PlayerSkill SkillManager => skillManager;
    public Vector2 Direction => direction;

    void Start() {
		state = new PlayerStateMachine(anim, this, statManager);
		state.Initialize();
	}

	void Update() {
		state.Update();
        if (JoyStick.instance.Direction != Vector2.zero)
            direction = JoyStick.instance.Direction;
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
            itemScript.PickUp();
    }


}
