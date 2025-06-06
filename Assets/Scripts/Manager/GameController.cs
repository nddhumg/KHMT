using Core.Spawn.Enemy;
using System.Collections;
using System.Collections.Generic;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class GameController : PersistentSingleton<GameController>
{
    [SerializeField] protected string mapId;
    protected VictoryAchieved victoryAchieved;
    protected IStat statPlayer;
    [SerializeField] protected SOStat soStatPlayerBase;

#if UNITY_EDITOR 
    [SerializeField] protected bool isDebugMode = false;
#endif
    private void Start()
    {
        statPlayer = soStatPlayerBase.Clone();
        statPlayer.Add(InventoryManager.instance.StatsBonus);
        InventoryManager.instance.StatsBonus.OnChangeStat += (key, value) => 
        { 
            statPlayer.SetStatValue(key, value + soStatPlayerBase.GetStatValue(key)); 
        };

#if UNITY_EDITOR
        if (isDebugMode)
        {
            Init("1");
        }
#endif
    }


    public IStat StatPlayer
    {
        get => statPlayer ?? soStatPlayerBase;
        set => statPlayer = value;
    }
    private void Update()
    {
        victoryAchieved?.Update();
    }

    public void Init(string mapId)
    {
        this.mapId = mapId;
        CreateVictoryAchieved(mapId);
        CreateMap(mapId);

    }


    protected void CreateVictoryAchieved(string mapId)
    {
        victoryAchieved = new TimeBasedVictory(10);
    }

    protected void CreateMap(string mapId)
    {
        var mapHandle = Addressables.InstantiateAsync($"Assets/Prefabs/Map/Map{mapId}.prefab");
        EnemySpawn.instance.Init(mapId, new SpawnZones(new Vector3(1f, 1f)));
    }
}