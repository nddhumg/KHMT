
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Singleton<EnemySpawn> {

    [SerializeField] protected SpawnZones spawnZones;
    protected List<SpawnRate> possibleWaveEnemies = new List<SpawnRate>();
    [SerializeField] protected List<SOSpawnRate> allSpawnableEnemies;
    [SerializeField] protected SOSpawnWave waveCurrent;
    protected SpawnEnemyInfo info;
    protected float timeNextWave = 0;
    protected bool isWavePeak = false;
    protected float operationTimePeak;

    protected int enemyCount = 0;

    protected CoolDownTimer spawnTimer;

    public int EnemyCount { get => enemyCount; set { enemyCount = value; } }

    protected void Start() {
        spawnTimer = new CoolDownTimer();
        spawnTimer.OnCoolDownEnd += SpawnWave;

        isWavePeak = waveCurrent.IsSpawnPeak;
        if (!isWavePeak)
        {
            SetSpawnInfo(waveCurrent.SpawnEnemyInfo);
        }
        timeNextWave += waveCurrent.SpawnEnemyInfo.operationTimeMinutes;

        possibleWaveEnemies = allSpawnableEnemies[0].SpawnRateList;
    }
    private void Update()
    {
        spawnTimer.CountTime(Time.deltaTime);
        if (CanNextWave())
        {
            NextWave();
        }
        if (isWavePeak && IsPeakTimeOver())
        {
            EndPeak();
        }
    }

    protected bool IsPeakTimeOver(){
        return Time.timeSinceLevelLoad < operationTimePeak;
    }

    protected void SetSpawnInfo(SpawnEnemyInfo infoNew) {
        info = infoNew;
        spawnTimer.CoolDown = info.spawnIntervalSeconds;
    }

    protected bool CanNextWave()
    {
        return Time.timeSinceLevelLoad / 60f > timeNextWave;
    }

    protected void NextWave() {
        waveCurrent = waveCurrent.NextWave;

        isWavePeak = waveCurrent.IsSpawnPeak;
        if (isWavePeak)
        {
            operationTimePeak = waveCurrent.SpawnEnemyInfo.operationTimeMinutes * 60 + Time.timeSinceLevelLoad;
            SetSpawnInfo(waveCurrent.SpawnPeak.info);
        }
        else
        {
            SetSpawnInfo(waveCurrent.SpawnEnemyInfo);
        }
        timeNextWave += waveCurrent.SpawnEnemyInfo.operationTimeMinutes;
    }

    protected void EndPeak() { 
        info = waveCurrent.SpawnEnemyInfo;
        spawnTimer.CoolDown = waveCurrent.SpawnEnemyInfo.spawnIntervalSeconds;
    }

    protected virtual void SpawnWave()
	{
        if (IsSpawnMax())
            return;
		GameObject enemy;
        enemyCount += info.spawnAmount;
		for (int i = 0; i < info.spawnAmount; i++) {
            enemy = GetRandomEnemy();
			EnemyPool.instance.Spawn(enemy, spawnZones.GetRandomSpawnPosition(), Quaternion.identity);
		}
	}

    private bool IsSpawnMax() { 
        return info.maxEnemySpawn <= enemyCount;
    }

    private GameObject GetRandomEnemy()
    {
        float rateRandom = Random.value;
        float rateCurrent = 0;
        foreach (SpawnRate rateEnemy in possibleWaveEnemies)
        {
            rateCurrent += rateEnemy.Rate;
            if (rateRandom <= rateCurrent)
                return rateEnemy.Prefab;
        }
        return null;

    }

}
