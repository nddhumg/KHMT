using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Spawn/Enemy")]
public class SOSpawnEnemy : ScriptableObject
{
    [SerializeField] List<SpawnEnemyInfo> spawnEnemy;
#if UNITY_EDITOR
    [Button]
    public void GetData()
    {
        spawnEnemy.Clear();
        foreach (var data in CsvCollectionManager.Container.SpawnEnemy)
        {
            SpawnEnemyInfo infoWave = new SpawnEnemyInfo(
                 Regex.Replace(data.Id, @"\s+", string.Empty),
                 data.EnemyTransitionTime,
                 data.GetEnemysId(out var enemyRate)
                 , enemyRate);
            spawnEnemy.Add(infoWave);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
    public ISpawnEnemyInfo GetSpawnEnemyInfo(string mapid, int level)
    {
        foreach (ISpawnEnemyInfo spawnEnemy in spawnEnemy)
        {
            string[] id = spawnEnemy.Id.Split('.');
            if (id[0] == mapid && id[1] == level.ToString())
            {
                return spawnEnemy;
            }
        }
        Debug.LogError($"No data for map {mapid} level {level}");
        return null;
    }
}
[System.Serializable]
public class SpawnEnemyInfo : ISpawnEnemyInfo
{
    [SerializeField] string id;
    [SerializeField] float enemyTransitionTime;
    [SerializeField] List<string> enemysId;
    [SerializeField] List<float> rateEnemy;

    public SpawnEnemyInfo(string id, float enemyTransitionTime, List<string> enemysId, List<float> rateEnemy)
    {
        this.id = id;
        this.enemyTransitionTime = enemyTransitionTime;
        this.enemysId = enemysId;
        this.rateEnemy = rateEnemy;
    }

    public string Id => id;

    public float EnemyTransitionTime => enemyTransitionTime;

    public List<string> EnemyIdSpawn => enemysId;

    public List<float> EnemyRate => rateEnemy;

}

