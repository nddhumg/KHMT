using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnEnemyInfo
{
    string Id { get; }
    float EnemyTransitionTime { get; }
    List<string> EnemyIdSpawn { get; }
    List<float> EnemyRate { get; }

}
