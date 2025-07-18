
using System;
using EnumName;
using Systems.SaveLoad;
using UnityEngine;

public class ResourceController : PersistentSingleton<ResourceController>
{
    [SerializeField, ReadOnly] protected ResourceData data ;
    [SerializeField] protected int energyMax = 30;
    [SerializeField] protected float energyRegenTimeMinutes = 5;
    protected float timer = 0;
    public Action<ResourceName> OnChangeResource;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnApplicationQuit()
    {
        SaveLoadSystem.DataService.Save<ResourceData>(ref data);
    }

    void Start() {
        data = SaveLoadSystem.DataService.Load<ResourceData>(gameObject) ?? new();
        OfflineEnergy();

    }

    void Update() {
        if (!IsMaxEnergy())
        {
            RegenerateEnergy();
        }
    }
    public void IncreaseResource(ResourceName resource, int value)
    {
        if (resource == ResourceName.Coin)
        {
            data.coin += value;
        }
        else if (resource == ResourceName.CoinVip)
        {
            data.coinVip += value;
        }
        else
        {
            data.energy += value;
            if (data.energy > energyMax) data.energy = energyMax;
        }
        OnChangeResource?.Invoke(resource);
    }

    public bool DecreaseResource(ResourceName resource, uint value)
    {
        ref int resourceRef = ref GetResourceRef(resource);
        if (resourceRef >= value)
        {
            resourceRef -= (int)value;
            OnChangeResource?.Invoke(resource);
            return true;
        }
        else {
            return false;
        }
    }


    public int GetResource(ResourceName resource)
    {
        switch (resource)
        {
            case ResourceName.Coin:
                return data.coin;
            case ResourceName.CoinVip:
                return data.coinVip;
            case ResourceName.Energy:
                return data.energy;
            case ResourceName.EnergyMax:
                return energyMax;

        }
        return 0;
    }

    protected ref int GetResourceRef(ResourceName resource)
    {
        switch (resource)
        {
            case ResourceName.Coin: return ref data.coin;
            case ResourceName.CoinVip: return ref data.coinVip;
            case ResourceName.Energy: return ref data.energy;
            default: throw new ArgumentException("Invalid resource type");
        }
    }

    protected void OfflineEnergy(){
        TimeSpan offlineDuration = (DateTime.Now - TimeManager.instance.GameExitTime);
        float offlineRecoveredEnergy = offlineDuration.Minutes / energyRegenTimeMinutes;
        if (offlineRecoveredEnergy + data.energy >= energyMax)
        {
            data.energy = energyMax;
        }
        else
        {
            IncreaseResource(ResourceName.Energy, (int)offlineRecoveredEnergy);
            timer = Mathf.FloorToInt(offlineRecoveredEnergy * 60) + offlineDuration.Seconds / 60f;
        }
    }

    protected void RegenerateEnergy(){
        timer += Time.deltaTime;
        if (timer/ 60f >= this.energyRegenTimeMinutes) {
            timer = 0;
            IncreaseResource(ResourceName.Energy, 1);
            OnChangeResource?.Invoke(ResourceName.Energy);
        }
    }

    protected bool IsMaxEnergy() { 
        return data.energy >= energyMax;
    }

}
