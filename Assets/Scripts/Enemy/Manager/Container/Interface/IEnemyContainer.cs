using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyContainer 
{
    GameObject GetEnemy(string id);
    public List<GameObject> GetEnemies(List<string> ids);
}
