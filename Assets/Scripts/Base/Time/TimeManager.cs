using System;
using System.Data;
using Systems.SaveLoad;
using UnityEngine;

public class TimeManager : PersistentSingleton<TimeManager>
{

    [SerializeField, ReadOnly] TimeData data;

    public DateTime GameExitTime =>  DateTime.Parse(data.gameExitTime);
    protected override void Awake()
    {
        base.Awake();
        data = SaveLoadSystem.DataService.Load<TimeData>();
    }

    private void OnApplicationQuit()
    {
        data.gameExitTime = DateTime.Now.ToString();
        SaveLoadSystem.DataService.Save<TimeData>(ref data);
    }

}
