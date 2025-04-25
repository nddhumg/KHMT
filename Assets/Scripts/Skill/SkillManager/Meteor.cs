using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Skill {
    public class Meteor : MonoBehaviour
    {
        private DamageSkillComponent damageComponent;
        private CoolDownSkillComponent coolDownComponent;
        [SerializeField] private GameObject meteorObject;
        [SerializeField] private LayerMask layerCheck;

        private void Start()
        {
            damageComponent = new DamageSkillComponent(1,Player.instance.StatsManager.StatCurrent);
            coolDownComponent = new CoolDownSkillComponent(1);
            coolDownComponent.Timer.OnCoolDownEnd += Attack;
        }

        private void Update()
        {
            coolDownComponent.Update();
        }


        void Attack() {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, CameraMain.instance.Size, 0f, layerCheck);
            if (colliders.Length == 0)
                return;
            Vector2 positionTarget = colliders[Random.Range(0, colliders.Length)].transform.position;
            Vector2 positionSpawn = new Vector2();
            positionSpawn.x = positionTarget.x + (Random.value >= 0.5 ? 1 : -1) * CameraMain.instance.Size.x;
            float angle = Random.Range(45, 89);
            positionSpawn.y = positionTarget.y + Mathf.Tan(angle * Mathf.Deg2Rad) * Mathf.Abs(positionTarget.x - positionSpawn.x);
            GameObject meteor = Instantiate(meteorObject, positionSpawn, Quaternion.identity);
            meteor.GetComponent<MeteorObject>().Init(positionTarget, damageComponent.GetDamge());

        }

    }
}
