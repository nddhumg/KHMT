using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Cooldown;
using UnityEngine.Rendering;

public class NercromancerBullet : MonoBehaviour
{
    [SerializeField] protected DestroyAfterTime destroyAfterTime;
    [SerializeField] protected MoveInDirection moveInDirection;

    private void Start()
    {
        ResetState();
    }


    private void OnDisable()
    {
        ResetState();
    }

    public void MoveToPlayer()
    {
        destroyAfterTime.Timer.Start();
        moveInDirection.Direction =  Player.instance.transform.position - transform.position;
        moveInDirection.CanMove = true;
    }

    protected void ResetState()
    {
        moveInDirection.CanMove = false;
        destroyAfterTime.Timer.Pause();
    }
}
