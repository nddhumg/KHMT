using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetContainer : SheetContainerBase
{
    public SheetContainer(Microsoft.Extensions.Logging.ILogger logged) : base(logged)
    {
        SpawnWave = new();
        SpawnEnemy = new();
        SpawnBossSheet = new();
        GameMessagesSheet = new();
    }


    public SpawnWaveSheet SpawnWave { get; private set; }

    public SpawnEnemySheet SpawnEnemy { get; private set; }

    public SpawnBossSheet SpawnBossSheet { get; private set; }

    public GameMessagesSheet GameMessagesSheet { get; private set; }
}

