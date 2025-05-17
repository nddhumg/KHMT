using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Skill
{
    public class BulletBiA : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private MoveInDirection move;
        CameraMain mainCamera;
        private BiA skill;

        [SerializeField] private uint maxCollider = 3;

        public uint MaxCollider
        {
            get
            {
                return maxCollider;
            }
            set
            {
                maxCollider = value;
            }
        }

        private void Start()
        {
            mainCamera = CameraMain.instance;

        }

        public void Init(uint maxCollider, BiA biA)
        {
            this.maxCollider = maxCollider;
            this.skill = biA;
        }


        void Update()
        {
            Vector3 pos = transform.position;
            if ((pos.x <= mainCamera.MinCameraBounds.x + radius && move.Direction.x < 0) || (pos.x >= mainCamera.MaxCameraBounds.x - radius && move.Direction.x > 0))
            {
                float posColliderX = move.Direction.x < 0 ? mainCamera.MinCameraBounds.x + radius : mainCamera.MaxCameraBounds.x - radius;
                move.Direction = new Vector2(move.Direction.x * -1, move.Direction.y);
                maxCollider -= 1;
                EffectPool.instance.Spawn(skill.EffectCollider, new Vector3(posColliderX, pos.y, 0f), Quaternion.identity);
            }

            if ((pos.y <= mainCamera.MinCameraBounds.y + radius && move.Direction.y < 0) || (pos.y >= mainCamera.MaxCameraBounds.y - radius && move.Direction.y > 0))
            {
                float posColliderY = move.Direction.y < 0 ? mainCamera.MinCameraBounds.y + radius : mainCamera.MaxCameraBounds.y - radius;
                move.Direction = new Vector2(move.Direction.x, move.Direction.y * -1);
                maxCollider -= 1;
                EffectPool.instance.Spawn(skill.EffectCollider, new Vector3(pos.x, posColliderY, 0f), Quaternion.identity);
            }

            if (maxCollider <= 0)
                gameObject.SetActive(false);
        }



    }
}
