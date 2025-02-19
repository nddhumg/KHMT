using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleStat : PlayerState
{
    public PlayerIdleStat(PlayerStateMachine playerState) : base(playerState)
    {
    }

    public override void CheckChangeState()
    {
        base.CheckChangeState();
        if (JoyStick.instance.Direction != Vector2.zero) {
            playerState.ChangeState(playerState.moveState);
        }
    }
}
