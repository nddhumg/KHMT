using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArc : Enemy
{
    [SerializeField] protected GameObject bullet;

    public GameObject Bullet => bullet;
    private void Awake()
    {
        state = new EnemyArcStateManager(this, stat);
    }
}
