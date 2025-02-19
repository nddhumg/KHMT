using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IItemPickUp
{
    [SerializeField] protected Animator animator;
    protected int coin;
    protected int coinMax;
    
    public void PickUpAble()
    {
        coin = Random.Range(0, coinMax);
        GameSystem.Pause();
        GameSystem.AddCoin(coin);
    }

}
