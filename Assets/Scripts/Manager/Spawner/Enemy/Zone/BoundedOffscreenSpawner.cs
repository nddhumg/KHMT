
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Core.Spawn.Enemy
{
    public class BoundedOffscreenSpawner : ISpawnZone
    {
        [SerializeField] protected Vector2 min;
        [SerializeField] protected Vector2 max;
        [SerializeField] protected Vector2 randomMaxDistance;
        [SerializeField] protected Vector2 randomMinDistance;
        public BoundedOffscreenSpawner(Vector2 min, Vector2 max, Vector2 randomMaxDistance)
        {
            this.min = min;
            this.max = max;
            this.randomMaxDistance = randomMaxDistance;
        }

        public Vector2 GetRandomSpawnPosition()
        {
            Vector2 spawnPosition = new Vector2();
            float left = CameraMain.instance.CameraBottomLeft.x;
            float right = CameraMain.instance.CameraBottomRight.x;
            float top = CameraMain.instance.CameraTopLeft.y;
            float bottom = CameraMain.instance.CameraBottomLeft.y;

            List<Vector2> side = new List<Vector2> { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

            Vector2 sideSelect;
            while (side.Count != 0) {
                int index = Random.Range(0, side.Count);
                sideSelect = side[index];
                if (sideSelect == Vector2.up && top + randomMaxDistance.y < max.y)
                {
                    spawnPosition.y = top + Random.Range(randomMinDistance.y, randomMaxDistance.y);
                    spawnPosition.x = Random.Range(left, right);
                    break;
                }
                else if (sideSelect == Vector2.down && bottom - randomMaxDistance.y > min.y)
                {
                    spawnPosition.y = bottom - Random.Range(randomMinDistance.y, randomMaxDistance.y);
                    spawnPosition.x = Random.Range(left, right);
                    break;
                }
                else if (sideSelect == Vector2.left && left - randomMaxDistance.x > min.x)
                {
                    spawnPosition.y = Random.Range(bottom, top);
                    spawnPosition.x = left - Random.Range(randomMinDistance.x, randomMaxDistance.x);
                    break;
                }
                else if (sideSelect == Vector2.right && right + randomMaxDistance.x < max.x) {
                    spawnPosition.y = Random.Range(bottom, top);
                    spawnPosition.x = right + Random.Range(randomMinDistance.x, randomMaxDistance.x);
                    break;
                }
                side.RemoveAt(index);
            }
            return spawnPosition;
        }
    }
}
