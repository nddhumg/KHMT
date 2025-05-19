using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawn.Enemy
{
    public class EnemySelector 
    {
        protected string idMap;
        protected int wave = 1;
        protected SOSpawnEnemy soEnemySpawn;
        protected SOEnemyContainer soEnemyContainer;
        protected IWeightedRandomSelector<GameObject> weightedRandomSelector;
        protected ICoolDownAuto timer;

        public EnemySelector(string idMap, int wave, SOSpawnEnemy soEnemySpawn, SOEnemyContainer soEnemyContainer)
        {
            this.idMap = idMap;
            this.wave = wave;
            this.soEnemySpawn = soEnemySpawn;
            this.soEnemyContainer = soEnemyContainer;

            weightedRandomSelector = new WeightedRandomSelector<GameObject>();
            timer = new AutoCooldownTimer(timeScale: 60f);
            GetEnemyWave(wave);
            timer.AddTimeoutListener(() => GetEnemyWave(wave++));
        }

        public void Update()
        {
            timer.UpdateCooldown(Time.deltaTime);
        }

        public GameObject GetEnemySpawn()
        {
            return weightedRandomSelector.GetRandomItem();
        }

        private void GetEnemyWave(int wave)
        {
            ISpawnEnemyInfo enemyInfo = soEnemySpawn.GetSpawnEnemyInfo(idMap, wave);
            if (enemyInfo == null)
            {
                timer.ClearTimeoutListeners();
                return;
            }
            timer.Cooldown = enemyInfo.EnemyTransitionTime;
            weightedRandomSelector.AddItems(soEnemyContainer.GetEnemies(enemyInfo.EnemyIdSpawn), enemyInfo.EnemyRate);
        }
    }
}
