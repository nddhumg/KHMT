using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Spawn/AllWave")]
public class SOSpawnWave : ScriptableObject , ICsvImport
{
    [SerializeField] private List<SpawnData> waveData = new List<SpawnData>();

    [Button]
    public void GetData()
    {
        waveData.Clear();
        foreach (var data in CsvCollectionManager.Container.SpawnWave) {
            SpawnData infoWave = new SpawnData(data.Id,new List<ISpawnWaveInfo>(data.Arr));
            waveData.Add(infoWave);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

    public SpawnData GetWaveInfo(string mapId) {
        return waveData.Find(info => info.id == mapId);
    }
}

[System.Serializable]
public class SpawnData : ISpawnWave
{
    public string id;
    public List<SpawnWaveInfo> infoWave;

    public SpawnData(string key, List<ISpawnWaveInfo> wavesInfo)
    {
        id = key;

        infoWave = new List<SpawnWaveInfo>();
        foreach (var wave in wavesInfo)
        {
            infoWave.Add(new SpawnWaveInfo(wave));
        }
    }

    public string Key { get; }

    public int CountInfo { get; }

    public ISpawnWaveInfo GetInfoSpawnEnemy(int indexWave)
    {
        return infoWave[indexWave];
    }
}



