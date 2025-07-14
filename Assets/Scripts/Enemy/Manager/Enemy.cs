using Core.Spawn.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ndd.Stat;


namespace Core.Enemies
{
    public abstract class Enemy : MonoBehaviour, IReceiveDamage
    {
        protected EnemyStateManager state;
        [SerializeField] protected Transform spriteTf;
        [SerializeField] protected SOStat statBase;
        protected float hp;
        protected IStat statCurrent;


        [SerializeField] protected DropItem dropItem;

        public IStat StatCurrent => statCurrent;

        public void Flip()
        {
            spriteTf.localScale = new Vector3(-1 * spriteTf.localScale.x, spriteTf.localScale.y, spriteTf.localScale.z);
        }

        public int GetDirectionLook()
        {
            return spriteTf.localScale.x > 0 ? 1 : -1;
        }

        protected virtual void Start()
        {
            CreateStateManager();
            state.Initialize();
        }

        protected void OnEnable()
        {
            Init();
        }
        public virtual void Init()
        {
            if (statCurrent == null)
            {
                statCurrent = statBase.Clone();
            }
            hp = statBase.GetStatValue(StatName.HpMax) * EnemyManager.instance.Stat.GetBonusHp();
            statCurrent.SetStatValue(StatName.Damage, statBase.GetStatValue(StatName.HpMax) * EnemyManager.instance.Stat.GetBonusDamage());
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
            EffectManager.instance.Pool.Take(EffectManager.instance.PopupDamage, transform.position, Quaternion.identity).GetComponent<PopupDamage>().SetText(damage);
            if (hp <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            dropItem.Drop(transform.position);
            gameObject.SetActive(false);
            EnemySpawn.instance.EnemyCount--;
            EnemySpawn.instance.EnemyKill++;
        }

        protected abstract void CreateStateManager();
    }

}