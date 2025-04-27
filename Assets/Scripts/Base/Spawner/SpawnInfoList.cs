using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Spawn/WaveList")]
public class SpawnInfoList : ScriptableObject
{
    [SerializeField]public  string path = "Assert/CSV/SpawnInfo.csv";

    public List<SpawnEnemyInfo> data;

    [Button]
    private void LoadData() {
        data = CSVImporter.Parse<SpawnEnemyInfo>(path);
    }
}
