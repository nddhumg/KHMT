using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawn.Enemy
{
    public class UnboundedOffscreenSpawner : ISpawnZone
    {
        private Vector2 randomMaxDistance;

        public UnboundedOffscreenSpawner(Vector2 randomMaxDistance)
        {
            this.randomMaxDistance = randomMaxDistance;
        }

        public virtual Vector2 GetRandomSpawnPosition()
        { 
            Vector3 spawnPosition = new Vector3();
            Vector2 side;
            Vector2 pointInBounded = CameraMain.instance.GetRandomPointInBounded(out side);
            if (side.x == 0)
            {
                spawnPosition.x = pointInBounded.x - Random.Range(0.2f, randomMaxDistance.x);
                spawnPosition.y = pointInBounded.y;
            }
            else if (side.x == 1)
            {
                spawnPosition.x = pointInBounded.x + Random.Range(0.2f, randomMaxDistance.x);
                spawnPosition.y = pointInBounded.y;
            }
            else if (side.y == 0)
            {
                spawnPosition.y = pointInBounded.y - Random.Range(0.2f, randomMaxDistance.y);
                spawnPosition.x = pointInBounded.x;
            }
            else if (side.y == 1)
            {
                spawnPosition.y = pointInBounded.y + Random.Range(0.2f, randomMaxDistance.y);
                spawnPosition.x = pointInBounded.x;
            }
            return spawnPosition;
        }

        protected int GetRandomSign()
        {
            return Random.value <= 0.5f ? -1 : 1;
        }
    }
}
