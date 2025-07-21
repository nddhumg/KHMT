using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SpawnBossSheet : Sheet<SpawnBossSheet.Row>
{
    public class Row : SheetRowArray<Boss>
    {

    }
    public class Boss : SheetRowElem
    {
        public string BossId { get; private set; }
        public float TimeSpawn { get; private set; }
    }

}

