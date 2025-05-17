using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnWaveInfo : ISpawnWaveInfo
{
    public int spawnAmount = 5;
    public int maxEnemySpawn = 30;
    public float spawnIntervalSeconds = 3f;
    public float operationTimeMinutes;

    public SpawnWaveInfo(int spawnAmount, int maxEnemySpawn, float spawnIntervalSeconds, float operationTimeMinutes)
    {
        this.spawnAmount = spawnAmount;
        this.maxEnemySpawn = maxEnemySpawn;
        this.spawnIntervalSeconds = spawnIntervalSeconds;
        this.operationTimeMinutes = operationTimeMinutes;
    }
    public SpawnWaveInfo(ISpawnWaveInfo waveInfo)
    {
        this.spawnAmount = waveInfo.SpawnAmount;
        this.maxEnemySpawn = waveInfo.MaxEnemySpawn;
        this.spawnIntervalSeconds = waveInfo.SpawnIntervalSeconds;
        this.operationTimeMinutes = waveInfo.OperationTimeMinutes;
    }

    public int SpawnAmount => spawnAmount;

    public int MaxEnemySpawn => maxEnemySpawn;

    public float SpawnIntervalSeconds => spawnIntervalSeconds;

    public float OperationTimeMinutes => operationTimeMinutes;
}