
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Singleton<EnemySpawn>
{
    string mapId = "1";
    [SerializeField] protected SpawnZones spawnZones;
    [SerializeField]protected List<SpawnRate> possibleWaveEnemies = new List<SpawnRate>();
    protected EnemyStatBonusByLevelPlayer stat;


    [SerializeField] protected SOSpawnWave soSpawnWave;
    protected ISpawnWaveInfo info;
    protected float timeNextWave = 0;
    protected int indexWave = 0;

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
        SetUpNextWave();
    }

    protected virtual void SpawnWave()
    {
        if (IsSpawnMax())
            return;
        enemyCount += info.SpawnAmount;
        SpawnRate spawnRate;
        for (int i = 0; i < info.SpawnAmount; i++)
        {
            spawnRate = GetRandomSpawnRate();
            EnemyPool.instance.Spawn(spawnRate.Prefab, spawnZones.GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    private bool IsSpawnMax()
    {
        return info.MaxEnemySpawn <= enemyCount;
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
        info = soSpawnWave.GetWaveInfo(mapId).GetInfoSpawnEnemy(indexWave);
        indexWave++;
        timeNextWave += info.OperationTimeMinutes;
        //possibleWaveEnemies = waveCurrent.EnemysSpawn;
        spawnTimer.CoolDown = info.SpawnIntervalSeconds;
    }
}
