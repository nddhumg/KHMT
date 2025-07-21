
using Core.Spawn.Enemy;
using Systems.Inventory;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Ndd.Stat;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
public class GameController : PersistentSingleton<GameController>
{
    [SerializeField] protected string mapId = "1";
    protected IStat statPlayer;
    [SerializeField] protected SOStat soStatPlayerBase;
    protected ISpawnZone spawnZone;
    protected IMapData mapData;

    public ISpawnZone SpawnZone => spawnZone;
    public string MapId => mapId;
    public IMapData MapData => mapData;

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

    public async Task LoadAddressableMap(string mapid)
    {
        this.mapId = mapid;

        AssetLabelReference assertlabel = new();
        assertlabel.labelString = $"Map{mapId}Data";
        var mapHandle = Addressables.LoadAssetsAsync<Object>(assertlabel, null);
        await mapHandle.Task;

        if (mapHandle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var assert in mapHandle.Result)
            {
                if (assert is SOMap soMap)
                {
                    mapData = soMap;
                    spawnZone = new UnboundedOffscreenSpawner(new Vector3(2, 2));
                }
            }
        }
    }
    public void Init()
    {
        if (MapData.Map != null)
        {
            GameObject Map = Instantiate(mapData.Map);
            SetConfinerCameraForMap(Map);
        }
        else {
            Debug.LogError("Not data map in soMap");
        }
        StartupEffect();
    }

    protected void SetConfinerCameraForMap(GameObject map)
    {
        var mapComponent = map.GetComponent<MapController>();
        CameraMain.instance.SetConfinerCollider(mapComponent.Col);
    }

    protected void StartupEffect()
    {
        foreach (var upgrade in GlobalUpgradeManager.instance.UpgradeOnStart.Values)
        {
            upgrade.ApplyUpgrade();
        }
    }
}