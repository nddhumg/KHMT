using Ndd.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    IPoolObject<GameObject, GameObject> pool;
    [SerializeField] private Transform holder;
    [SerializeField] private SOExpSpawn soExpSpawn;

    protected ExpSpawn expSpawn;
    //protected ItemEnemyDrop itemEnemyDrop;

    public IPoolObject<GameObject, GameObject> Pool => pool;
    protected override void Awake()
    {
        base.Awake();
        expSpawn = new ExpSpawn(new Ndd.Random.ChanceSelectorRandom<GameObject>(),soExpSpawn);
        pool = new PoolGameObject(holder);
    }

    void Update() {
        expSpawn.Update();
    }

    public GameObject SpawnExp(Vector3 position) {
        return pool.Take(expSpawn.GetExpSpawn(), position, Quaternion.identity);
    }
}
