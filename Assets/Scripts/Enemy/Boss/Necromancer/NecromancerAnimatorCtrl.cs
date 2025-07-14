using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NecromancerAnimEventName { 
    AttackHit,
    Finish
}

public enum NecromancerAnimName
{
    Attack1,
    Idle,
    Health,
}


public class NecromancerAnimatorCtrl : MonoBehaviour, IAnimEventSource
{
    [SerializeField] protected Animator animator;
    public event Action<string> EventAnim;

    public void OnAttackHit() {
        EventAnim?.Invoke(NecromancerAnimEventName.AttackHit.ToString());
    }

    public void OnFinish() {
        EventAnim?.Invoke(NecromancerAnimEventName.Finish.ToString());
    }

    public void Play(string name)
    {
        animator.Play(name);
    }
}
