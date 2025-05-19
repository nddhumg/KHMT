using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemies
{
    public class EnemyArc : Enemy
    {
        [SerializeField] protected GameObject bullet;

        public GameObject Bullet => bullet;

        protected override void CreateStateManager()
        {
            state = new EnemyArcStateManager(this,bullet);
        }
    }
}
