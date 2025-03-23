using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.SaveLoad;
public class TutorialControl : PersistentSingleton<TutorialControl>
{
    [SerializeField,ReadOnly]TutorialData data;
    
    public bool IsFirstInGame => data.isFirstInGame;

    protected override void Awake()
    {
        base.Awake();
        data = SaveLoadSystem.DataService.Load<TutorialData>();
    }

    private void Start()
    {
    }

    private void OnApplicationQuit()
    {
        data.isFirstInGame = false;
        SaveLoadSystem.DataService.Save<TutorialData>(ref data);
    }
}
