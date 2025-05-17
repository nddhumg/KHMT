using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IReceiveDamage
{
    protected EnemyStateManager state;
    [SerializeField] protected Transform spriteTf;
    [SerializeField] protected SOStat statBase;
    protected float hp;

    [SerializeField] protected DropItem dropItem;

    public void Flip()
    {
        spriteTf.localScale = new Vector3(-1 * spriteTf.localScale.x, spriteTf.localScale.y, spriteTf.localScale.z);
    }

    public int GetDirectionLook()
    {
        return spriteTf.localScale.x > 0 ? 1 : -1;
    }

    //protected 
    protected void Start() {
        CreateStateManager();
        state.Initialize();
    }

    protected void OnEnable() {
        Init();
        //EnemySpawn.instance.Enemies.Add(gameObject);
    }

    protected void OnDisable()
    {
        //EnemySpawn.instance.Enemies.Remove(gameObject);
    }

    public virtual void Init()
    {
        //hp = statBase.GetStatValue(EnumName.Stat.HpMax) * EnemySpawn.instance.Stat.GetBonusHp();
    }

    protected virtual void Update()
    {
        state.Update();
    }

    void FixedUpdate()
    {
        state.FixedUpdate();
    }

    public Transform GetPlayer()
    {
        return Player.instance.transform;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }

    protected void Dead()
    {
        dropItem.Drop(transform.position);
        gameObject.SetActive(false);
            EnemySpawn.instance.EnemyCount--;
        EnemySpawn.instance.EnemyKill++;
    }

    protected abstract void CreateStateManager();
}
