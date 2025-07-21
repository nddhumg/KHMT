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

    }
    public class Enemy : SheetRowElem
    {
        public string EnemyId { get; private set; }
        public float Rate { get; private set; }
    }
}
