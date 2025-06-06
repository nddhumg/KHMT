using UnityEngine;

namespace Core.Spawn.Enemy
{
    public interface ISpawnZone 
    {
        public Vector2 GetRandomSpawnPosition();
    }
}
