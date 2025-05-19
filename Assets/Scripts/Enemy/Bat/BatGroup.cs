using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemies
{
    public class BatGroup : Enemy
    {
        [SerializeField] protected Enemy[] batEntity;
        protected override void CreateStateManager()
        {
            state = new BatStateManager(this);
        }
    }
}
