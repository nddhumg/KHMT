using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour, IItemPickUp {
    [SerializeField] protected uint exp;
    [SerializeField] protected SOExp dataExp;
    private bool isBeingPulled = false;

    public void PickUpAble()
    {
        Player.instance.Level.ExpUp(exp);
        gameObject.SetActive(false);
    }

    void OnEnable() {
        Magnet.pickUpMagnet += Pull;
    }

    void OnDisable()
    {
        isBeingPulled = false;
        Magnet.pickUpMagnet -= Pull;
    }

    void Update() {
        MoveToPlayer();
    }

    private void OnValidate()
    {
        if (dataExp != null)
            exp = dataExp.ExpValue;
    }
    private void MoveToPlayer() {
        if (isBeingPulled) 
        transform.position = Vector3.Slerp(transform.position, Player.instance.transform.position, 2 * Time.deltaTime);
    }

    private void Pull() {
        SetIsBeingPulled(true);
    }

    private void SetIsBeingPulled(bool isPulled) 
    {
        this.isBeingPulled = isPulled;
    }
}
