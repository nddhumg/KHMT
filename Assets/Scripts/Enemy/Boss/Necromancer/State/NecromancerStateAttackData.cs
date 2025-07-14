using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NecromancerStateAttackData 
{
    public GameObject bullet;
    public int countBullet;

    public Vector3 spawnCenter;
    public float spawnRadius;
    public Transform holderBullet;
}
