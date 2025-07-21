using Ndd.Cooldown;
using Ndd.Random;
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
        protected IEnemyContainer enemyContainer;
        protected IRandomSelector<GameObject> weightedRandomSelector;
        protected ICoolDownAuto timer;
        protected ICoolDownAuto timerCheckWave;

        public EnemySelector(string idMap, int wave, SOSpawnEnemy soEnemySpawn, IEnemyContainer enemyContainer)
        {
            this.idMap = idMap;
            this.wave = wave;
            this.soEnemySpawn = soEnemySpawn;
            this.enemyContainer = enemyContainer;

            weightedRandomSelector = new GuaranteedSelectorRandom<GameObject>();
            timer = new AutoCooldownTimer(timeScale: 1/60);
            timerCheckWave = new AutoCooldownTimer(timeScale: 1 / 60);
            timerCheckWave.AddTimeoutListener(NewxtWave);
            GetEnemyWave(wave);
            timer.AddTimeoutListener(() => GetEnemyWave(wave++));
        }

        public void Update()
        {
            timer.UpdateCooldown(Time.deltaTime);
            timerCheckWave.UpdateCooldown(Time.deltaTime);
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
            weightedRandomSelector.AddItems(enemyContainer.GetEnemies(enemyInfo.EnemyIdSpawn), enemyInfo.EnemyRate);
        }

        private void NewxtWave() {
            wave++;
            GetEnemyWave(wave);
        }
    }
}
