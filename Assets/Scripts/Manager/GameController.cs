
using Core.Spawn.Enemy;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Ndd.Stat;
using UnityEngine.ResourceManagement.AsyncOperations;
public class GameController : PersistentSingleton<GameController>
{
    [SerializeField] protected string mapId;
    protected IStat statPlayer;
    [SerializeField] protected SOStat soStatPlayerBase;
    [SerializeField, ReadOnly] protected string idMap = "1";

    public string MapId => mapId;

    private void Start()
    {
        statPlayer = soStatPlayerBase.Clone();
        statPlayer.Add(InventoryManager.instance.StatsBonus);
        InventoryManager.instance.StatsBonus.OnStatChangedValue += (key, value) =>
        {
            statPlayer.IncreaseStat(key, value);
        };

        statPlayer.Add(GlobalUpgradeManager.instance.StatBonus);
        GlobalUpgradeManager.instance.StatBonus.OnStatChangedValue += (key, value) =>
        {
            statPlayer.IncreaseStat(key, value);
        };
    }


    public IStat StatPlayer
    {
        get => statPlayer ?? soStatPlayerBase;
    }
    public void Init(string mapId)
    {
        var handle = Addressables.LoadAssetAsync<SOMap>($"Assets/ScriptableObject/Map/Map{mapId}.asset");
        handle.Completed += (AsyncOperationHandle<SOMap> handle) =>
        {
            var mapData = handle.Result;
            WinManager.instance.AddWinCondition(mapData.AnyWinCondition, WinManager.WinConditionGroupType.Any);
            WinManager.instance.AddWinCondition(mapData.AllWinCondition, WinManager.WinConditionGroupType.All);
            CreateGame(mapId);
        };
    }

    public void CreateGame(string mapId)
    {
        this.mapId = mapId;

        AssetLabelReference assertlabel = new();
        assertlabel.labelString = $"Map{mapId}Data";
        Addressables.LoadAssetsAsync<GameObject>(assertlabel, null);
        var handle = Addressables.InstantiateAsync($"Assets/Prefabs/Map/Map{mapId}.prefab");
        handle.Completed += SetConfinerCameraForMap;
        EnemySpawn.instance.Init(mapId, new UnboundedOffscreenSpawner(new Vector3(2, 2)));
        StartupEffect();
    }

    public void OnCreateSceneGame()
    {
        //statPlayer.Add(InventoryManager.instance.StatsBonus);
        //InventoryManager.instance.StatsBonus.OnStatChangedValue += (key, value) =>
        //{
        //    statPlayer.IncreaseStat(key, value);
        //};

        //statPlayer.Add(GlobalUpgradeManager.instance.StatBonus);
        //    GlobalUpgradeManager.instance.StatBonus.OnStatChangedValue += (key, value) =>
        //    {
        //        statPlayer.IncreaseStat(key, value);
        //    };
    }

    protected void SetConfinerCameraForMap(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject mapObj = handle.Result;

            var mapComponent = mapObj.GetComponent<MapController>();
            CameraMain.instance.SetConfinerCollider(mapComponent.Col);
        }
        else
        {
            Debug.LogError("Failed to instantiate map prefab.");
        }
    }

    protected void StartupEffect()
    {
        foreach (var upgrade in GlobalUpgradeManager.instance.UpgradeOnStart.Values)
        {
            upgrade.ApplyUpgrade();
        }
    }
}