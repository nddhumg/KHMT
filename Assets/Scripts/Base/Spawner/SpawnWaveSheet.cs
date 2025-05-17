using Cathei.BakingSheet;
using Cathei.BakingSheet.Unity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class SpawnWaveSheet : Sheet<SpawnWaveSheet.Row>
{
    public class Row : SheetRowArray<SpawnEnemyInfo>, ISpawnWave
    {


        public ISpawnWaveInfo GetInfoSpawnEnemy(int level)
        {
            return this[level];
        }

        

        public int CountInfo => Count;

        public string Key => throw new System.NotImplementedException();
    }

    public class SpawnEnemyInfo : SheetRowElem, ISpawnWaveInfo
    {
        public int SpawnAmount { get; private set; }
        public int MaxEnemySpawn { get; private set; }
        public float SpawnIntervalSeconds { get; private set; }
        public float OperationTimeMinutes { get; private set; }
    }
}
