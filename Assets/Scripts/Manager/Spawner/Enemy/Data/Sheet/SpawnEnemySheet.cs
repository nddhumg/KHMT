using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SpawnEnemySheet : Sheet<SpawnEnemySheet.Row>
{
    public class Row : SheetRowArray<Enemy>
    {
        public float EnemyTransitionTime { get; private set; }

        public List<string> GetEnemysId(out List<float> rateEnemy) {

            rateEnemy = new();
            List<string> enemyId = new();
            foreach (Enemy enemy in this)
            {
                enemyId.Add(Regex.Replace(enemy.EnemyRate.EnemyId, @"\s+", string.Empty));
                rateEnemy.Add(enemy.EnemyRate.Rate);
            }
            return enemyId;
        }
    }
    public class Enemy : SheetRowElem
    {
        public EnemyRate EnemyRate { get;private set; }

    }

    public struct EnemyRate { 
        public string EnemyId { get; private set; }
        public float Rate { get; private set; }
    }

}
