using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetContainer : SheetContainerBase
{
    public SheetContainer(Microsoft.Extensions.Logging.ILogger logged) : base(logged)
    {
        SpawnWave = new();
    }


    public SpawnWaveSheet SpawnWave { get; private set; }


}

