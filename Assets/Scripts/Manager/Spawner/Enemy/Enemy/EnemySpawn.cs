
using Ndd.Cooldown;
using Ndd.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawn.Enemy
{
    public class EnemySpawn : Singleton<EnemySpawn>
    {
        string mapId = "1";
        [SerializeField] protected static ISpawnZone spawnZone;

        [Header("EnemySpawn")]
        protected EnemySelector enemySelector;
        [SerializeField] protected SOSpawnEnemy soEnemySpawn;
        [SerializeField] protected SOEnemyContainer soEnemyContainer;

        [Header("SpawnWave")]
        [SerializeField] protected SOSpawnWave soSpawnWave;
        protected ISpawnWaveInfo info;
        protected float timeNextWave = 0;
        protected int indexWave = 0;
        protected bool isNextWave = true;

        [SerializeField, ReadOnly] protected int enemyCount = 0;
        [SerializeField, ReadOnly] protected int enemyDie = 0;

        protected ICoolDownAuto spawnTimer;
        protected IPoolObject<GameObject, GameObject> poolEnemy;


        public int EnemyCount { get => enemyCount; set => enemyCount = value; }
        public int EnemyKill { get => enemyDie; set => enemyDie = value; }

        protected void Start()
        {
            Init();
            poolEnemy = EnemyManager.instance.Pool;
            CreateTimerSpawn();
            SetUpNextWave();

        }
        private void Update()
        {
            enemySelector?.Update();
            spawnTimer.UpdateCooldown(Time.deltaTime);
            if (CanNextWave())
            {
                NextWave();
            }
        }

        public void Init() {
            this.mapId = GameController.instance.MapId;
            enemySelector = new EnemySelector(mapId, 1, soEnemySpawn, soEnemyContainer);
            spawnZone = GameController.instance.SpawnZone;
        }

        protected bool CanNextWave()
        {
            return Time.timeSinceLevelLoad / 60f > timeNextWave && isNextWave;
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
                poolEnemy.Take(enemySelector.GetEnemySpawn(), spawnZone.GetRandomSpawnPosition(), Quaternion.identity);
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
            if (soSpawnWave.GetWaveInfo(mapId).GetInfoSpawnEnemy(indexWave) == null) { 
                isNextWave = false;
                return;
            }
            info = soSpawnWave.GetWaveInfo(mapId).GetInfoSpawnEnemy(indexWave);
            indexWave++;
            timeNextWave += info.OperationTimeMinutes;
            spawnTimer.Cooldown = info.SpawnIntervalSeconds;
        }
    }
}