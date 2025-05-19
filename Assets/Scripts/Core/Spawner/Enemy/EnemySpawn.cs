
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawn.Enemy
{
    public class EnemySpawn : Singleton<EnemySpawn>
    {
        string mapId = "1";
        [SerializeField] protected ISpawnZone spawnZone;
        protected EnemyStatBonusByLevelPlayer stat;

        [Header("EnemySpawn")]
        protected EnemySelector enemySelector;
        [SerializeField] protected SOSpawnEnemy soEnemySpawn;
        [SerializeField] protected SOEnemyContainer soEnemyContainer;

        [Header("SpawnWave")]
        [SerializeField] protected SOSpawnWave soSpawnWave;
        protected ISpawnWaveInfo info;
        protected float timeNextWave = 0;
        protected int indexWave = 0;

        [SerializeField, ReadOnly] protected int enemyCount = 0;
        [SerializeField, ReadOnly] protected int enemyDie = 0;

        protected ICoolDownAuto spawnTimer;


        public EnemyStatBonusByLevelPlayer Stat => stat;

        public int EnemyCount { get => enemyCount; set => enemyCount = value; }
        public int EnemyKill { get => enemyDie; set => enemyDie = value; }

        protected void Start()
        {
            stat = new EnemyStatBonusByLevelPlayer(Player.instance.Level);
            spawnZone = new SpawnZones(new Vector3(1f,1f));
            enemySelector = new EnemySelector(mapId, 1, soEnemySpawn, soEnemyContainer);
            CreateTimerSpawn();
            SetUpNextWave();
        }
        private void Update()
        {
            enemySelector.Update();
            spawnTimer.UpdateCooldown(Time.deltaTime);
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
            for (int i = 0; i < info.SpawnAmount; i++)
            {
                EnemyPool.instance.Spawn(enemySelector.GetEnemySpawn(), spawnZone.GetRandomSpawnPosition(), Quaternion.identity);
            }
        }

        private bool IsSpawnMax()
        {
            return info.MaxEnemySpawn <= enemyCount;
        }


        private void CreateTimerSpawn()
        {
            spawnTimer = new AutoCooldownTimer();
            spawnTimer.AddTimeoutListener(SpawnWave);
        }

        private void SetUpNextWave()
        {
            info = soSpawnWave.GetWaveInfo(mapId).GetInfoSpawnEnemy(indexWave);
            indexWave++;
            timeNextWave += info.OperationTimeMinutes;
            spawnTimer.Cooldown = info.SpawnIntervalSeconds;
        }
    }
}