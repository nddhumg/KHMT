using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Spawn/Wave")]
public class SOSpawnWave : ScriptableObject
{
    [SerializeField] protected SpawnEnemyInfo info = new SpawnEnemyInfo();
    [SerializeField] protected SOSpawnWave nextWave;
    [SerializeField] protected List<SpawnRate> enemysSpawn;

    public SpawnEnemyInfo SpawnEnemyInfo => info;

    public List<SpawnRate> EnemysSpawn => enemysSpawn; 

    public SOSpawnWave NextWave => nextWave;
}

