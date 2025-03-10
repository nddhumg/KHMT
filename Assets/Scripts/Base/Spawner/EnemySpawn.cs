
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Singleton<EnemySpawn>
{

    [SerializeField] protected SpawnZones spawnZones;
    protected List<SpawnRate> possibleWaveEnemies = new List<SpawnRate>();
    [SerializeField] protected SOSpawnWave waveCurrent;
    protected EnemyStatBonusByLevelPlayer stat;

    protected SpawnEnemyInfo info;
    protected float timeNextWave = 0;

    [SerializeField, ReadOnly] protected int enemyCount = 0;
    [SerializeField, ReadOnly] protected int enemyDie = 0;

    protected CoolDownTimer spawnTimer;

    public EnemyStatBonusByLevelPlayer Stat => stat;

    public int EnemyCount { get => enemyCount; set => enemyCount = value; }
    public int EnemyKill { get => enemyDie; set => enemyDie = value; }

    protected void Start()
    {
        stat = new EnemyStatBonusByLevelPlayer(Player.instance.Level);
        CreateTimerSpawn();
        SetUpNextWave();
    }
    private void Update()
    {
        spawnTimer.CountTime(Time.deltaTime);
        if (CanNextWave())
        {
            NextWave();
        }
    }

    protected bool CanNextWave()
    {
        return Time.timeSinceLevelLoad / 60f > timeNextWave;
    }

    protected void NextWave()
    {
        if(waveCurrent.NextWave == null)
        {
            Debug.Log("No next wave");
            return;
        }
        waveCurrent = waveCurrent.NextWave;
        SetUpNextWave();
    }

    protected virtual void SpawnWave()
    {
        if (IsSpawnMax())
            return;
        enemyCount += info.spawnAmount;
        bool isGetFromPool;
        GameObject enemy;
        SpawnRate spawnRate;
        for (int i = 0; i < info.spawnAmount; i++)
        {
            spawnRate = GetRandomSpawnRate();
            enemy = EnemyPool.instance.Spawn(spawnRate.Prefab, spawnZones.GetRandomSpawnPosition(), Quaternion.identity, out isGetFromPool);
        }
    }

    private bool IsSpawnMax()
    {
        return info.maxEnemySpawn <= enemyCount;
    }

    private SpawnRate GetRandomSpawnRate()
    {
        float rateRandom = Random.value;
        float rateCurrent = 0;
        foreach (SpawnRate rateEnemy in possibleWaveEnemies)
        {
            rateCurrent += rateEnemy.Rate;
            if (rateRandom <= rateCurrent)
                return rateEnemy;
        }
        return null;
    }

    private void CreateTimerSpawn()
    {
        spawnTimer = new CoolDownTimer();
        spawnTimer.OnCoolDownEnd += SpawnWave;
    }

    private void SetUpNextWave()
    {
        info = waveCurrent.SpawnEnemyInfo;
        timeNextWave += info.operationTimeMinutes;
        possibleWaveEnemies = waveCurrent.EnemysSpawn;
        spawnTimer.CoolDown = info.spawnIntervalSeconds;
    }
}
