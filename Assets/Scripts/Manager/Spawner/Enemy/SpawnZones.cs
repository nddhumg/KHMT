using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawn.Enemy
{
    public class SpawnZones : ISpawnZone
    {
        private Vector2 randomMaxDistance;
        private Vector3 positionCamera = new();
        private Vector2 randomDistanceCamera = new Vector2();
        private Vector3 spawnPosition = new Vector3();

        public SpawnZones(Vector2 randomMaxDistance)
        {
            this.randomMaxDistance = randomMaxDistance;
        }

        public Vector2 GetRandomSpawnPosition()
        {
            Vector2 sizeCamera = CameraMain.instance.Size;
            sizeCamera = sizeCamera / 2;
            positionCamera = Camera.main.transform.position;
            randomDistanceCamera.x = Random.Range(0f, sizeCamera.x + randomMaxDistance.x);
            randomDistanceCamera.y = Random.Range(randomDistanceCamera.x <= sizeCamera.x ? sizeCamera.y : 0, sizeCamera.y + randomMaxDistance.y);

            spawnPosition.x = randomDistanceCamera.x * GetRandomSign() + positionCamera.x;
            spawnPosition.y = randomDistanceCamera.y * GetRandomSign() + positionCamera.y;
            return spawnPosition;
        }

        protected int GetRandomSign()
        {
            return Random.value <= 0.5f ? -1 : 1;
        }
    }
}
