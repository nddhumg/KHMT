using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Pool;

public class BulletManager : Singleton<BulletManager> {
	protected IPoolObject<GameObject, GameObject> pool;
    [SerializeField] private Transform holder; 

    public IPoolObject<GameObject, GameObject> Pool => pool;

    protected override void Awake()
    {
        base.Awake();
        pool = new PoolGameObject(holder);
    }
}

