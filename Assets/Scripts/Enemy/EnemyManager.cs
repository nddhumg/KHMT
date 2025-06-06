using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Ndd.Pool;
using Core.Enemies;
public class EnemyManager : Singleton<EnemyManager> {
    protected IPoolObject<GameObject, GameObject> pool;
    [SerializeField] private Transform holder;

    protected EnemyStatBonusByLevelPlayer statBonus;
    public IPoolObject<GameObject, GameObject> Pool => pool;

    public EnemyStatBonusByLevelPlayer Stat => statBonus;

    protected override void Awake() {
        base.Awake();
        pool = new PoolGameObject(holder);
    }

    protected virtual void Start() {
        statBonus = new EnemyStatBonusByLevelPlayer(Player.instance.Level);
    }

    [Button]
    public void ClearEnemy() { 
        foreach (KeyValuePair<GameObject, List<GameObject>> kvp in pool.Pool) {
            foreach (GameObject obj in kvp.Value) {
                if (obj.activeSelf) {
                    obj.GetComponent<Enemy>().Dead();
                }
            }
        }
    }

}
