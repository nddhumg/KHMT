using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CreateAssetMenu(menuName ="SO/Spawn/Boss",fileName ="BossData")]
public class SOBossSpawn : ScriptableObject
{
    [SerializeField, ReadOnly] List<BossSpawnData> bossSpawnData = new();
#if UNITY_EDITOR
    [Button]
    public void GetData()
    {
        bossSpawnData.Clear();
        foreach (var data in CsvCollectionManager.Container.SpawnBossSheet)
        {
            var dataBoss = new BossSpawnData(data.Id);
            dataBoss.entry = data.OrderBy(r => r.TimeSpawn).Select(r => new BossSpawnEntry { bossid = r.BossId, timeSpawn = r.TimeSpawn }).ToList();
            bossSpawnData.Add(dataBoss);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

#endif

    public IBossSpawnData GetBossSpawnPlan(string idMap) {
        foreach (var bossSpawn in bossSpawnData) { 
            if(bossSpawn.mapid == idMap)
                return bossSpawn;
        }
        return null;
    }
}
[System.Serializable]
public class BossSpawnData :IBossSpawnData
{
    public string mapid;
    public List<BossSpawnEntry> entry = new();

    public BossSpawnData(string mapid)
    {
        this.mapid = mapid;
    }

    public List<BossSpawnEntry> BossSpawnEntry => entry;
}
[System.Serializable]
public class BossSpawnEntry
{
    public string bossid;
    public float timeSpawn;
}
