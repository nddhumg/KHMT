using System;
using System.Data;
using Systems.SaveLoad;
using UnityEngine;

public class TimeManager : PersistentSingleton<TimeManager>
{

    [SerializeField, ReadOnly] TimeData data = new();

    public DateTime GameExitTime =>  DateTime.Parse(data.gameExitTime);
    private void Start()
    {
        data = SaveLoadSystem.DataService.Load<TimeData>(gameObject) ?? data;
    }


    private void OnApplicationQuit()
    {
        data.gameExitTime = DateTime.Now.ToString();
        SaveLoadSystem.DataService.Save<TimeData>(ref data);
    }

    public TimeSpan ConvertSecondsToTimeSpan(float seconds)
    {
        return TimeSpan.FromSeconds(seconds);
    }
}
