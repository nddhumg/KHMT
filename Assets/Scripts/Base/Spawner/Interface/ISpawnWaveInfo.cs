using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnWaveInfo
{
    int SpawnAmount { get; }
    int MaxEnemySpawn { get; }
    float SpawnIntervalSeconds { get; }
    float OperationTimeMinutes { get; }
}