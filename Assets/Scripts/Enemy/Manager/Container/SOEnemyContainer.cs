using Core.Enemies;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Manager/ContainerEnemy", fileName = "ContainerEnemy")]
public class SOEnemyContainer : ScriptableObject
{

    [SerializeField] private List<ModelEnemy> modelEnemy;
    private Dictionary<string, GameObject> containerEnemy = new();

    [System.Serializable]
    private class ModelEnemy : IModelEnemy
    {
        [SerializeField] private EnemyName id;
        [SerializeField] private GameObject enemy;

        public string Id => id.ToString();

        public GameObject Enemy => enemy;
    }

    public GameObject GetEnemy(string id) {
        try
        {
            return containerEnemy[id];
        }
        catch {
            CreateContainer();
            return containerEnemy[id];
        }
    }

    public List<GameObject> GetEnemies(List<string> ids) {
        List<GameObject> enemies = new List<GameObject>();
        foreach (string id in ids) { 
            enemies.Add(GetEnemy(id));
        }
        return enemies;
    }

    [Button]
    private void CreateContainer()
    {
        containerEnemy.Clear();
        foreach (IModelEnemy model in modelEnemy)
        {
            containerEnemy.Add(model.Id, model.Enemy);
        }
    }

}
