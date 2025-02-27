using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Spawn/Wave")]
public class SOSpawnWave : ScriptableObject
{
    [SerializeField] protected SpawnEnemyInfo info = new SpawnEnemyInfo();
    [SerializeField] protected SOSpawnPeak spawnPeak;
    [SerializeField] protected SOSpawnWave nextWave;

    public bool IsSpawnPeak => spawnPeak != null;
    public SpawnEnemyInfo SpawnEnemyInfo => info;
    public SOSpawnPeak SpawnPeak => spawnPeak;

    public SOSpawnWave NextWave => nextWave;
}

