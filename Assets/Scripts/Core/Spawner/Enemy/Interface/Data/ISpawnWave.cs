using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnWave
{
    public string Key { get; }

    public ISpawnWaveInfo GetInfoSpawnEnemy(int level);

    public int CountInfo { get; }
}
