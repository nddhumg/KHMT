using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill {
    public class MeteorObject : MonoBehaviour
    {
        Vector3 positionTarget;
        [SerializeField]float radiusAOE;
        int damage;
        Vector3 vectoLookAt = new Vector3();

        public void Init(Vector3 positionTarget,int damage) { 
            this.positionTarget = positionTarget;
            this.damage = damage;
            vectoLookAt = positionTarget - transform.position;
            transform.eulerAngles = new Vector3(0,0, -Vector2.Angle(Vector2.right, vectoLookAt));
            transform.DOMove(positionTarget, 1f).onComplete += DamageSenderAOE;
        }


        void DamageSenderAOE() {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusAOE);

            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<IReceiveDamage>()?.TakeDamage(damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector2 position = transform.position;
            float radius = radiusAOE;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position, radius);
        }
    }
}
