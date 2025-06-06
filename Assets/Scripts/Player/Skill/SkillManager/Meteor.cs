using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Skill
{
    public class Meteor : MonoBehaviour
    {
        private DamageSkillComponent damageComponent;
        private CoolDownSkillComponent coolDownComponent;
        [SerializeField] private GameObject meteorObject;
        [SerializeField] private LayerMask layerCheck;
        [SerializeField] private float coolDownTime = 3f;

        private void Start()
        {
            damageComponent = new DamageSkillComponent(1, Player.instance.StatsManager.StatCurrent);
            coolDownComponent = new CoolDownSkillComponent(coolDownTime);
            coolDownComponent.Timer.AddTimeoutListener(Attack);
        }

        private void Update()
        {
            coolDownComponent.Update();
        }


        void Attack()
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, CameraMain.instance.Size, 0f, layerCheck);
            if (colliders.Length == 0)
                return;

            Vector2 positionTarget = colliders[Random.Range(0, colliders.Length)].transform.position;

            Vector2 positionSpawn = GetPositionSpawn(positionTarget);
            GameObject meteor = BulletManager.instance.Pool.Take(meteorObject, positionSpawn, Quaternion.identity);
            meteor.GetComponent<MeteorObject>().Init(positionTarget, damageComponent.GetDamge());

        }

        private Vector2 GetPositionSpawn(Vector2 positionTarget)
        {
            Vector2 positionSpawn = new Vector2();
            positionSpawn.x = positionTarget.x + CameraMain.instance.Size.x * Random.Range(-1f,1f);
            float angle = Random.Range(45, 90);
            float opposite = Mathf.Max(Mathf.Abs(positionTarget.x - positionSpawn.x), Vector2.Distance(CameraMain.instance.MaxCameraBounds, positionTarget));
            positionSpawn.y = positionTarget.y + Mathf.Sin(angle * Mathf.Deg2Rad) * opposite;

            return positionSpawn;
        }

    }
}
