using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Skill
{
    public class RadiantBlast : MonoBehaviour
    {
        protected CoolDownSkillComponent coolDownComponent;
        protected DamageSkillComponent damageComponent;
        [SerializeField] protected float radius = 1f;
        [SerializeField] protected LayerMask layerEnemy;
        public CoolDownSkillComponent CoolDownComponent => coolDownComponent;
        public DamageSkillComponent DamageComponent => damageComponent;

        protected virtual void Start()
        {
            coolDownComponent = new CoolDownSkillComponent(0.5f);
            coolDownComponent.Timer.OnCoolDownEnd += Attack;
            damageComponent = new DamageSkillComponent(1, Player.instance.StatsManager.StatCurrent);
        }

        protected void Update()
        {
            coolDownComponent.Update();
        }
        public void IncreaseSkillRange(float amount)
        {
            float scaleCurent = transform.localScale.x;
            float scaleNew = scaleCurent + amount;
            transform.localScale = new Vector3(scaleNew, scaleNew, 1f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        private void Attack()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerEnemy);

            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<IReceiveDamage>().TakeDamage(damageComponent.GetDamge());
            }
        }

    }
}
