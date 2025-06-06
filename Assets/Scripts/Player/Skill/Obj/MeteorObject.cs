using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace Core.Skill
{
    public class MeteorObject : MonoBehaviour
    {
        Vector3 positionTarget;
        [SerializeField] float radiusAOE;
        int damage;
        [SerializeField] float timerSpeed = 1.5f;
        Vector3 vectorLookAt = new Vector3();
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject effectTrail;

        [SerializeField] private ParticleSystem particaleDestroy;

        public void Init(Vector3 positionTarget, int damage)
        {
            this.positionTarget = positionTarget;
            this.damage = damage;
            vectorLookAt = positionTarget - transform.position;
            transform.eulerAngles = new Vector3(0, 0, -Vector2.Angle(Vector2.right, vectorLookAt));
            StartCoroutine(Move());
            //Tween moveTween = transform.DOMove(positionTarget, timerSpeed);
            //moveTween.onComplete += DamageSenderAOE;
            //moveTween.onComplete += OnEventDestroy;
            spriteRenderer.enabled = true;
            effectTrail.SetActive(true);
        }

        IEnumerator Move()
        {
            while (!IsAtTarget())
            {
                transform.position = Vector2.MoveTowards(transform.position, positionTarget, timerSpeed * Time.deltaTime);
                yield return null;
            }
            DamageSenderAOE();
            OnEventDestroy();
            yield return null;
        }

        bool IsAtTarget()
        {
            float distanceTolerance = 0.2f;
            return Vector3.Distance(positionTarget, transform.position) <= distanceTolerance;
        }
        void DamageSenderAOE()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusAOE);

            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<IReceiveDamage>()?.TakeDamage(damage);
            }
        }

        private void OnEventDestroy()
        {
            particaleDestroy.Play();
            spriteRenderer.enabled = false;
            effectTrail.SetActive(false);
        }

        private void OnParticleSystemStopped()
        {
            gameObject.SetActive(false);
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
