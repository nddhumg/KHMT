using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemyInfo 
{
    public int spawnAmount = 5;
    public int maxEnemySpawn = 30;
    public float spawnIntervalSeconds = 3f;
    public float operationTimeMinutes;
}
