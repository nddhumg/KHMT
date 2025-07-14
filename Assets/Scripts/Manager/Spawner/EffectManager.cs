using Ndd.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    IPoolObject<GameObject, GameObject> pool;
    [SerializeField] protected Transform holder;
    [SerializeField] protected GameObject poupDamage;

    public GameObject PopupDamage => poupDamage;

    public IPoolObject<GameObject, GameObject> Pool => pool;
    protected override void Awake()
    {
        base.Awake();
        pool = new PoolGameObject(holder);
    }
}
