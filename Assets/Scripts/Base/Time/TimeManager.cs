using System;
using System.Data;
using Systems.SaveLoad;
using UnityEngine;

public class TimeManager : PersistentSingleton<TimeManager>, IBind<TimeData>
{

    [SerializeField, ReadOnly] TimeData data;
    public string ID { get; set; }

    public DateTime GameExitTime => DateTime.Parse(data.gameExitTime);
    public void Bind(TimeData data)
    {
        this.data = data;
        this.data.ID = ID;
    }

    void OnApplicationQuit()
    {
        data.gameExitTime = DateTime.Now.ToString();
    }
}
